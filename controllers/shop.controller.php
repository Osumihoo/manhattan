<?php

class ControllerShop {
    public function offer($DocEntry){
        try {
            $genericrfc = ModelShop::genericrfc();
            $paymentcondition = ModelShop::paymentcondition();
            $paymentmethods = ModelShop::paymentmethods();
            $wharehouse = ModelShop::wharehouse();
            $paymenthformath = ModelShop::paymentformath();
            $lines = ModelShop::linesForDocEntry($DocEntry);
            $products = ModelShop::productSAP($lines[0]['ListNum'],$lines[0]['WhsCode'],$lines[0]['CardCode']);
            $pricelist = ModelShop::priceLists();
            $directions = ModelShop::showDirectionForUser();
            
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
                $products[$key]['VATLiable'] = iconv("ISO-8859-1","UTF-8",$product['VATLiable']) == 'Y' ? true : false;
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
            $response['pricelist'] = $pricelist;
            
            message("message",$response);
            exit;
            // $offers = ModelOffer::alloffer($DocEntry);
            
            // message("message",$offers);  
            
        } catch (Exception $e) {
            messageErrorCode($e->getMessage(),200);
        }
    }

    public function alloffer($start,$finish,$salePerson){
        $offers = ModelShop::alloffer($start,$finish,$salePerson);
        
        message("message",$offers);
    }

    public function supplier(){
      $users = ModelShop::supplier();
      foreach($users as $key => $user) $users[$key]['CardName'] = iconv("ISO-8859-1","UTF-8",$user['CardName']);
      message("message",$users);
    }

    public function showDirection(){
        $directions = ModelShop::showDirectionForUser();
        foreach($directions as $key => $direction){
            $directions[$key]['Street'] = iconv("ISO-8859-1","UTF-8",$direction['Street']);
            $directions[$key]['Block'] = iconv("ISO-8859-1","UTF-8",$direction['Block']);
            $directions[$key]['City'] = iconv("ISO-8859-1","UTF-8",$direction['City']);
        }
        message("message",$directions);
    }

    public function informationSAP(){
        $genericrfc = ModelShop::genericrfc();
        $paymentcondition = ModelShop::paymentcondition();
        $paymentmethods = ModelShop::paymentmethods();
        $paymenthformath = ModelShop::paymentformath();
        $wharehouse = ModelShop::wharehouse();
        $directions = ModelShop::showDirectionForUser();
        $pricelist = ModelShop::priceLists();

        foreach($paymenthformath AS $key => $value){
            $paymenthformath[$key]['idsap'] = iconv("ISO-8859-1","UTF-8",$value['idsap']);
            $paymenthformath[$key]['value'] = iconv("ISO-8859-1","UTF-8",$value['value']);
        }
        $response['genericrfc'] = $genericrfc;
        $response['paymentcondition'] = $paymentcondition;
        $response['paymentmethods'] = $paymentmethods;
        $response['wharehouse'] = $wharehouse;
        $response['paymenthformath'] = $paymenthformath;
        $response['directions'] = $directions[0];
        $response['pricelist'] = $pricelist;
        
        message("message",$response);
    }

    public function productSAP($pricelist,$warehouse,$cardcode){
        $products = ModelShop::productSAP($pricelist,$warehouse,$cardcode);

        foreach($products as $key => $product){
            $products[$key]['ItemCode'] = iconv("ISO-8859-1","UTF-8",$product['ItemCode']);
            $products[$key]['CodeBars'] = iconv("ISO-8859-1","UTF-8",$product['CodeBars']);
            $products[$key]['ItemName'] = iconv("ISO-8859-1","UTF-8",$product['ItemName']);
            $products[$key]['Price'] = floatval($product['Price']);
            $products[$key]['WTLiable'] = iconv("ISO-8859-1","UTF-8",$product['WTLiable']) == 'Y' ? true : false;
            $products[$key]['VATLiable'] = iconv("ISO-8859-1","UTF-8",$product['VATLiable']) == 'Y' ? true : false;
            $products[$key]['OnHand'] = intval($product['OnHand'],10);
            $products[$key]['IsCommited'] = intval($product['IsCommited'],10);
            $products[$key]['Stock'] = intval($product['Stock'],10);
        }
        
        message("message",$products);
    }

    public function createShopOffer($fields){
        $layer = new ControllerServiceLayer();
        $response = $layer->querys($fields);
        
        message("message",$response);
    }
    
    public function updateShopOffer($fields){
        $layer = new ControllerServiceLayer();
        $response = $layer->querys($fields);
        
        // echo json_encode($fields);
        message("message",$response);
    }

    public function deleteShopOffer($fields){
        $DocTotal = floatval($fields->DocTotal) + floatval($fields->TaxTotal);
        $DocTotal = number_format($DocTotal,2,'.','');

        $layer = new ControllerServiceLayer();
        $response = $layer->querys(json_decode(json_encode(array(
            "url" => "PurchaseOrders($fields->DocEntry)",
            "method" => "GET",
            "body"=>[]
        ))));
        
        $lines = $response->DocumentLines;
        $newDocumentLines = [];
        $index = 0;

        foreach($lines AS $key => $value){
            if($fields->delElement->LineNum != $value->LineNum){
                $lines[$key]->LineNum = $index;
                $newDocumentLines[] = $lines[$key];
                $index = $index + 1;
            }
        }
        
        $response->DocumentLines = $newDocumentLines;
        $response->DocTotal = floatval($DocTotal);
        // print_r($newDocumentLines);


        $responseTwo = $layer->querys(json_decode(json_encode(array(
            "url"=>"PurchaseOrders($fields->DocEntry)",
            "method"=>"PUT",
            "body"=>$response
        ))));

        // echo json_encode($fields);
        message("message",$responseTwo);
    }
}