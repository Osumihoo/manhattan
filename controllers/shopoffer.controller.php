<?php

class ControllerShopOffer {
    public function offer($DocEntry){
        try {
            $genericrfc = ModelShopOffer::genericrfc();
            $paymentcondition = ModelShopOffer::paymentcondition();
            $paymentmethods = ModelShopOffer::paymentmethods();
            $wharehouse = ModelShopOffer::wharehouse();
            $paymenthformath = ModelShopOffer::paymentformath();
            $lines = ModelShopOffer::linesForDocEntry($DocEntry);
            $products = ModelShopOffer::productSAP($lines[0]['ListNum'],$lines[0]['WhsCode'],$lines[0]['CardCode']);
            $directions = ModelShopOffer::showDirectionForUser();

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
            
            
            message("message",$response);
            exit;
            // $offers = ModelOffer::alloffer($DocEntry);
            
            // message("message",$offers);  
            
        } catch (Exception $e) {
            messageErrorCode($e->getMessage(),200);
        }
    }

    public function alloffer($start,$finish,$salePerson){
        $offers = ModelShopOffer::alloffer($start,$finish,$salePerson);
        message("message",$offers);
    }

    public function supplier(){
      $users = ModelShopOffer::supplier();
      foreach($users as $key => $user) $users[$key]['CardName'] = iconv("ISO-8859-1","UTF-8",$user['CardName']);
      message("message",$users);
    }

    public function showDirection(){
        $directions = ModelShopOffer::showDirectionForUser();
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
        $directions = ModelShopOffer::showDirectionForUser();

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
        
        message("message",$response);
    }

    public function productSAP($pricelist,$warehouse,$cardcode){
        $products = ModelShopOffer::productSAP($pricelist,$warehouse,$cardcode);

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
}