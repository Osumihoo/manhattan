<?php

class ControllerApproval {
   public function offer($DocEntry){
      try {
          $genericrfc = ModelApproval::genericrfc();
          $paymentcondition = ModelApproval::paymentcondition();
          $paymentmethods = ModelApproval::paymentmethods();
          $wharehouse = ModelApproval::wharehouse();
          $paymenthformath = ModelApproval::paymentformath();
          $routes = ModelApproval::routes();
          $lines = ModelApproval::linesForDocEntry($DocEntry);
          $products = ModelApproval::productSAP($lines[0]['ListNum'],$lines[0]['WhsCode']);
          $directions = ModelApproval::showDirectionForUser($lines[0]['CardCode']);

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
          // $offers = ModelApproval::alloffer($DocEntry);
          
          // message("message",$offers);  
          
      } catch (Exception $e) {
          messageErrorCode($e->getMessage(),200);
      }
  }

  public function alloffer($start,$finish,$salePerson){
    try{
        $offers = ModelApproval::alloffer($start,$finish,$salePerson);
        $status = "";
        foreach($offers as $key => $draft){
            $ventas = $draft['Ventas'];
            $Contado = $draft['Contado'];
            $Credito = $draft['Credito'];

            if($Contado == 'NA' && $ventas == 'NA' && $Credito == 'NA' && $status == ''){
                $status = 'Pendiente';
            }

            if($ventas == 'NA' && $status == ''){
                if($Contado == 'NA') $status = $Credito;
                elseif($Credito == 'NA') $status = $Contado;
                
                if($Contado == 'Rechazado') $status = $Contado;
                elseif($Credito == 'Rechazado') $status = $Credito;

                if($Credito != 'NA' && $Contado != 'NA' && $status == ''){
                    if($Credito == 'Aprobado' && $Contado == 'Aprobado') $status = 'Aprobado';
                    else $status = 'Pendiente';
                } 
            }

            if($Contado == 'NA' && $status == ''){
                if($ventas == 'NA') $status = $Credito;
                elseif($Credito == 'NA') $status = $ventas;
                
                if($ventas == 'Rechazado') $status = $ventas; 
                elseif($Credito == 'Rechazado')$status = $Credito;

                if($Credito != 'NA' && $ventas != 'NA' && $status == ''){
                    if($Credito == 'Aprobado' && $ventas == 'Aprobado') $status = 'Aprobado';
                    else $status = 'Pendiente';
                }
            }

            if($Credito == 'NA' && $status == ''){
                if($ventas == 'NA') $status = $Contado;
                elseif($Contado == 'NA') $status = $ventas;

                if($ventas == 'Rechazado') $status = $ventas;
                elseif($Contado == 'Rechazado') $status = $Contado;

                if($Contado != 'NA' && $ventas != 'NA' && $status == ''){
                    if($Contado == 'Aprobado' && $ventas == 'Aprobado') $status = 'Aprobado';
                    else $status = 'Pendiente';
                } 
            }

            if($Contado != 'NA' && $ventas != 'NA' && $Credito != 'NA' && $status == ''){
                if($Contado == 'Aprobado' && $ventas == 'Aprobado' && $Credito == 'Aprobado') $status = 'Aprobado';
                else $status = 'Pendiente';
            }                         

            $offers[$key]['Status'] = $status;
            $status = '';
        }
        message("message",$offers);
    }catch (Exception $e){
        messageErrorCode($e->getMessage(),200);
    }
  }

  public function showUser(){
    $users = ModelApproval::showUser();
    foreach($users as $key => $user) $users[$key]['CardName'] = iconv("ISO-8859-1","UTF-8",$user['CardName']);
    message("message",$users);
  }

  public function showDirection($cardcode){
      $directions = ModelApproval::showDirectionForUser($cardcode);
      foreach($directions as $key => $direction){
          $directions[$key]['Street'] = iconv("ISO-8859-1","UTF-8",$direction['Street']);
          $directions[$key]['Block'] = iconv("ISO-8859-1","UTF-8",$direction['Block']);
          $directions[$key]['City'] = iconv("ISO-8859-1","UTF-8",$direction['City']);
      }
      message("message",$directions);
  }

  public function informationSAP(){
      $genericrfc = ModelApproval::genericrfc();
      $paymentcondition = ModelApproval::paymentcondition();
      $paymentmethods = ModelApproval::paymentmethods();
      $paymenthformath = ModelApproval::paymentformath();
      $wharehouse = ModelApproval::wharehouse();
      $routes = ModelApproval::routes();

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
      $products = ModelApproval::productSAP($pricelist,$warehouse);

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
      $approval = new ControllerApprovalRequest();
      $layer = new ControllerServiceLayer();
      $band = false;
      $activateApproval = json_decode(json_encode(array(
          'url'=>'ApprovalTemplates(6)',
          'method'=>'PATCH',
          'body'=>array(
              'IsActive'=>'tYES',
              'IsActiveWhenUpdatingDocuments'=>'tYES',
          )
      )));

      if($approval->WareHouseSN($fields->body->CardCode,$fields->body->U_Sucursal) && $band == false){
          $band = true;
          $response = $layer->querys($activateApproval);
          if(!is_null($response)) messageErrorCode('Error al aprovar el proceso de aprovación', 200);
      }
      if($approval->Counted($fields->body->CardCode,$fields->body->GroupNum) && $band == false){
          $band = true;
          $response = $layer->querys($activateApproval);
          if(!is_null($response)) messageErrorCode('Error al aprovar el proceso de aprovación', 200);
      }
      if($approval->CountedCC($fields->body->CardCode) && $band == false){
          $band = true;
          $response = $layer->querys($activateApproval);
          if(!is_null($response)) messageErrorCode('Error al aprovar el proceso de aprovación', 200);
      }

      
      $response = $layer->querys($fields);
      
      if($band){
          $activateApproval->body->IsActive = 'tNO';
          $response = $layer->querys($activateApproval);
      }

      message("message",$response);
  }

  public function updateOffer($fields){
      $layer = new ControllerServiceLayer();
      $response = $layer->querys($fields);
      
      message("message",$response);
  }
  
  public function createToDraft($DocEntry){
    $fields = json_decode(json_encode(array("DocEntry" => $DocEntry)));
    $cliente = curl_init();
    curl_setopt($cliente,CURLOPT_HTTPHEADER,array('Content-Type: application/json'));
    curl_setopt($cliente, CURLOPT_URL, "{$_ENV['SERVICES_URL_WCL']}Orders");
    curl_setopt($cliente, CURLOPT_POST, true);
    curl_setopt($cliente, CURLOPT_POSTFIELDS, json_encode($fields));
    curl_setopt($cliente, CURLOPT_RETURNTRANSFER, true);
    $response = curl_exec($cliente);
    curl_close($cliente);
    $response = json_decode($response);

    if(isset($response->conflicts)){
        $conflicts = $response->conflicts[0];
        messageErrorCode($conflicts->Description,200);
    }

    message("message", $response->DocEntry);
  }
}