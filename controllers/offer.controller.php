<?php

class ControllerOffer {
    public function offer($DocEntry){
        try {
            $genericrfc = ModelOffer::genericrfc();
            $paymentcondition = ModelOffer::paymentcondition();
            $paymentmethods = ModelOffer::paymentmethods();
            $wharehouse = ModelOffer::wharehouse();
            $paymenthformath = ModelOffer::paymentformath();
            $routes = ModelOffer::routes();
            $lines = ModelOffer::linesForDocEntry($DocEntry);
            $products = ModelOffer::productSAP($lines[0]['ListNum'],$lines[0]['WhsCode']);
            $directions = ModelOffer::showDirectionForUser($lines[0]['CardCode']);

            foreach($directions as $key => $direction){
                $directions[$key]['Street'] = iconv("ISO-8859-1","UTF-8",$direction['Street']);
                $directions[$key]['Block'] = iconv("ISO-8859-1","UTF-8",$direction['Block']);
                $directions[$key]['City'] = iconv("ISO-8859-1","UTF-8",$direction['City']);
            }

            foreach($products as $key => $product){
                $products[$key]['ItemCode'] = iconv("ISO-8859-1","UTF-8",$product['ItemCode']);
                $products[$key]['CodeBars'] = iconv("ISO-8859-1","UTF-8",$product['CodeBars']);
                $products[$key]['ItemName'] = iconv("ISO-8859-1","UTF-8",$product['ItemName']);
                $products[$key]['Price'] = floatval($product['Price']);
                $products[$key]['WTLiable'] = iconv("ISO-8859-1","UTF-8",$product['WTLiable']) == 'Y' ? true : false;
                $products[$key]['OnHand'] = intval($product['OnHand'],10);
                $products[$key]['IsCommited'] = intval($product['IsCommited'],10);
                $products[$key]['Stock'] = intval($product['Stock'],10);
            }
            
            foreach($paymenthformath AS $key => $value){
                $paymenthformath[$key]['idsap'] = iconv("ISO-8859-1","UTF-8",$value['idsap']);
                $paymenthformath[$key]['value'] = iconv("ISO-8859-1","UTF-8",$value['value']);
            }

            foreach($lines AS $key => $line){
                $index = array_search($line['ItemCode'], array_column($products,'ItemCode'));
                $lines[$key]['Comments'] =  iconv("ISO-8859-1","UTF-8",$line['Comments']);
                $lines[$key]['ItemName'] =  iconv("ISO-8859-1","UTF-8",$line['ItemName']);
                $lines[$key]['Stock'] = $products[$index]['Stock'];
                $lines[$key]['checked'] = false;
            }
            
            $response['genericrfc'] = $genericrfc;
            $response['paymentcondition'] = $paymentcondition;
            $response['paymentmethods'] = $paymentmethods;
            $response['wharehouse'] = $wharehouse;
            $response['paymenthformath'] = $paymenthformath;
            $response['lines'] = $lines;
            $response['products'] = $products;
            $response['directions'] = $directions;
            $response['routes'] = $routes;
            
            
            message("message",$response);
            exit;
            // $offers = ModelOffer::alloffer($DocEntry);
            
            // message("message",$offers);  
            
        } catch (Exception $e) {
            messageErrorCode($e->getMessage(),200);
        }
    }

    public function alloffer($start,$finish,$salePerson){
        $offers = ModelOffer::alloffer($start,$finish,$salePerson);
        
        message("message",$offers);
    }

    public function showUser(){
      $users = ModelOffer::showUser();
      foreach($users as $key => $user) $users[$key]['CardName'] = iconv("ISO-8859-1","UTF-8",$user['CardName']);
      message("message",$users);
    }

    public function showDirection($cardcode){
        $directions = ModelOffer::showDirectionForUser($cardcode);
        foreach($directions as $key => $direction){
            $directions[$key]['Street'] = iconv("ISO-8859-1","UTF-8",$direction['Street']);
            $directions[$key]['Block'] = iconv("ISO-8859-1","UTF-8",$direction['Block']);
            $directions[$key]['City'] = iconv("ISO-8859-1","UTF-8",$direction['City']);
        }
        message("message",$directions);
    }

    public function informationSAP(){
        $genericrfc = ModelOffer::genericrfc();
        $paymentcondition = ModelOffer::paymentcondition();
        $paymentmethods = ModelOffer::paymentmethods();
        $paymenthformath = ModelOffer::paymentformath();
        $wharehouse = ModelOffer::wharehouse();
        $routes = ModelOffer::routes();

        foreach($paymenthformath AS $key => $value){
            $paymenthformath[$key]['idsap'] = iconv("ISO-8859-1","UTF-8",$value['idsap']);
            $paymenthformath[$key]['value'] = iconv("ISO-8859-1","UTF-8",$value['value']);
        }
        $response['genericrfc'] = $genericrfc;
        $response['paymentcondition'] = $paymentcondition;
        $response['paymentmethods'] = $paymentmethods;
        $response['wharehouse'] = $wharehouse;
        $response['paymenthformath'] = $paymenthformath;
        $response['routes'] = $routes;
        
        message("message",$response);
    }

    public function productSAP($pricelist,$warehouse){
        $products = ModelOffer::productSAP($pricelist,$warehouse);

        foreach($products as $key => $product){
            $products[$key]['ItemCode'] = iconv("ISO-8859-1","UTF-8",$product['ItemCode']);
            $products[$key]['CodeBars'] = iconv("ISO-8859-1","UTF-8",$product['CodeBars']);
            $products[$key]['ItemName'] = iconv("ISO-8859-1","UTF-8",$product['ItemName']);
            $products[$key]['Price'] = floatval($product['Price']);
            $products[$key]['WTLiable'] = iconv("ISO-8859-1","UTF-8",$product['WTLiable']) == 'Y' ? true : false;
            $products[$key]['OnHand'] = intval($product['OnHand'],10);
            $products[$key]['IsCommited'] = intval($product['IsCommited'],10);
            $products[$key]['Stock'] = intval($product['Stock'],10);
        }
        
        message("message",$products);
    }

    public function createOffer($fields){
        $layer = new ControllerServiceLayer();
        $response = $layer->querys($fields);
        
        message("message",$response);
    }

    public function createOfferToSale($fields){
        try{

            /* Validamos el key para que pueda ser utilizado */
            $key = ModelOffer::createQueue();
            $lastKey = intval($key)-1;
            $status = 'waiting';

            while($status == 'waiting'){
                // Obtenemos un status antes
                $lastStatus = ModelOffer::getAQueue($lastKey);
                
                // En caso de no tener un status antes de nuestra key bajamos 1 numero buscando la key antes que nosotros
                if(sizeof($lastStatus) == 0 || !isset($lastStatus[0]['status'])) $lastKey -= 1;
                
                // En caso de obtener un resultado evaluamos el ultimo status
                if(sizeof($lastStatus) > 0){
                    $lastSta = $lastStatus[0]['status'];

                    // Buscamos que el anterior a nosotros ya este utilizado para avanzar
                    if($lastSta == 'used'){
                        ModelOffer::patchAQueue($key,'use');
                        $status = 'uses';
                    }
                }
                
                // echo json_encode(sizeof($lastStatus) == 0 || !isset($lastStatus[0]['status']));
                sleep(2);
            }
            /* -------------------------------------------- */

            $approval = new ControllerApprovalRequest();
            $layer = new ControllerServiceLayer();
            $templantes = [];
            $band = false;
            $activateApproval = json_decode(json_encode(array(
                'url'=>'ApprovalTemplates(6)',
                'method'=>'PATCH',
                'body'=>array(
                    'IsActive'=>'tYES',
                    'IsActiveWhenUpdatingDocuments'=>'tYES',
                    )
                )));
                if($approval->WareHouseSN($fields->body->CardCode,$fields->body->U_Sucursal)) $templantes[] = "ApprovalTemplates({$_ENV['TEMP_VENTA']})";
                if($approval->Counted($fields->body->CardCode,$fields->body->GroupNum) || $approval->CountedCC($fields->body->CardCode)) $templantes[] = "ApprovalTemplates({$_ENV['TEMP_CONTADO']})";
                if($approval->Credit($fields->body->CardCode,$fields->body->GroupNum,$fields->body->DocumentLines)) $templantes[] = "ApprovalTemplates({$_ENV['TEMP_CREDITO']})";

                foreach($templantes as $templante){
                    $activateApproval->url = $templante;
                    $responseTemplante = $layer->querys($activateApproval);
                    if(!is_null($responseTemplante)) messageErrorCode('Error al aprovar el proceso de aprovación', 200);
                }
                
                $response = $layer->querysApproval($fields);
                
                foreach($templantes as $templante){
                    $activateApproval->url = $templante;
                    $activateApproval->body->IsActive = 'tNO';
                    $responseTemplante = $layer->querys($activateApproval);
                    if(!is_null($responseTemplante)) messageErrorCode('Error al aprovar el proceso de aprovación', 200);
                }
                ModelOffer::patchAQueue($key,'used');
                if(!isset($response->error)) message("message",$response);
                else messageErrorCode($response->error->message->value,200);
        }catch(Exception $e){
            messageErrorCode($e->getMessage(),200);
        }
    }

    public function updateOffer($fields){
        $layer = new ControllerServiceLayer();
        $response = $layer->querys($fields);
        
        message("message",$response);
    }
}