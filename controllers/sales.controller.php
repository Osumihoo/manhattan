<?php

class ControllerSales {
    public function offer($DocEntry){
        try {
            $genericrfc = ModelSales::genericrfc();
            $paymentcondition = ModelSales::paymentcondition();
            $paymentmethods = ModelSales::paymentmethods();
            $wharehouse = ModelSales::wharehouse();
            $paymenthformath = ModelSales::paymentformath();
            $lines = ModelSales::linesForDocEntry($DocEntry);
            $routes = ModelOffer::routes();
            $products = ModelSales::productSAP($lines[0]['ListNum'],$lines[0]['WhsCode']);
            $directions = ModelSales::showDirectionForUser($lines[0]['CardCode']);

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
            // $offers = ModelSales::alloffer($DocEntry);
            
            // message("message",$offers);  
            
        } catch (Exception $e) {
            messageErrorCode($e->getMessage(),200);
        }
    }

    public function alloffer($start,$finish,$salePerson){
        $offers = ModelSales::alloffer($start,$finish,$salePerson);
        
        message("message",$offers);
    }

    public function showUser(){
      $users = ModelSales::showUser();
      foreach($users as $key => $user) $users[$key]['CardName'] = iconv("ISO-8859-1","UTF-8",$user['CardName']);
      message("message",$users);
    }

    public function showDirection($cardcode){
        $directions = ModelSales::showDirectionForUser($cardcode);
        foreach($directions as $key => $direction){
            $directions[$key]['Street'] = iconv("ISO-8859-1","UTF-8",$direction['Street']);
            $directions[$key]['Block'] = iconv("ISO-8859-1","UTF-8",$direction['Block']);
            $directions[$key]['City'] = iconv("ISO-8859-1","UTF-8",$direction['City']);
        }
        message("message",$directions);
    }

    public function informationSAP(){
        $genericrfc = ModelSales::genericrfc();
        $paymentcondition = ModelSales::paymentcondition();
        $paymentmethods = ModelSales::paymentmethods();
        $paymenthformath = ModelSales::paymentformath();
        $wharehouse = ModelSales::wharehouse();
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
        $products = ModelSales::productSAP($pricelist,$warehouse);

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

    public function createSales($fields){
        $layer = new ControllerServiceLayer();
        $response = $layer->querys($fields);
        
        message("message",$response);
    }

    public function updateOffer($fields){
        $layer = new ControllerServiceLayer();
        $response = $layer->querys($fields);
        
        message("message",$response);
    }
}