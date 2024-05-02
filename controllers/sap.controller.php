<?php

class ControllerSap {
    public function bills($start,$finish){
        try {
            $result = ModelSap::showInvoices($start,$finish);
            if(sizeof($result) == 0){
                message("message",$result);
                exit;
            }

            $CardCodes = "";

            foreach ($result as $key => $row){
               $CardCodes .= $row['CardCode'].",";
            }
            
            $CardCodes = ModelSap::showClients(substr($CardCodes,0,-1));
            $data = [];
            foreach($CardCodes as $code){
                $index = array_search($code['idsap'],array_column($result,'CardCode'));
                $data[] = array_merge($code,$result[$index]);
            }   

            message("message",$data);
         }
         catch (Exception $e) {
            messageErrorCode($e->getMessage(),200);
         }
    }

    public function allInvoices($CardCode,$start,$finish){
        try {
            $result = ModelSap::allInvoices($CardCode,$start,$finish);
            
            $slpcodes = "";
            foreach($result as $key => $invoice){
                $slpcodes .= $invoice['SlpCode'].",";
            }
            $slpcodes = ModelSap::showSalePerson(substr($slpcodes,0,-1));
            foreach($result as $key => $invoice){
                $index = array_search($invoice['SlpCode'],array_column($slpcodes,'idsap'));
                $result[$key]['createName'] = $slpcodes[$index]['name'];
                $date = explode("-",$result[$key]['DocDate']);
                $result[$key]['DocDate'] = substr($date[2],0,2)."/".$date[1]."/".$date[0];
            }

            message("message",$result);
         }
         catch (Exception $e) {
            messageErrorCode($e->getMessage(),200);
         }
    }
    
    public function detailInvoices($invoice){
        try {
            $result = ModelSap::detailInvoices($invoice);
            
            $iva = 0;
            $subtotal = 0;
            
            foreach($result as $key => $details){
                $details['ItemCode'];
                $details['Dscription'];
                $result[$key]['Dscription'] = iconv("ISO-8859-1","UTF-8",$details['Dscription']);
                $result[$key]['Quantity'] = intval($details['Quantity']);
                $result[$key]['PriceBefDi'] = floatval($details['PriceBefDi']);
                $result[$key]['DiscPrcnt'] = intval($details['DiscPrcnt']);
                $result[$key]['LineTotal'] = floatval($details['LineTotal']);
                
                $iva += $details['TaxCode'] == 'IVAV16' ? ($result[$key]['LineTotal'] * 0.16) : 0;
                $subtotal += $result[$key]['LineTotal'];
            }

            $dsn = null;
            $stmt = null;
            message('message', array("information"=>array("iva"=>$iva,"subtotal"=>$subtotal,"total"=>$iva+$subtotal),"items"=>$result));
         }
         catch (Exception $e) {
            messageErrorCode($e->getMessage(),200);
         }
    }

    public function directionsUser($CardCode){
        try {
            $result = ModelSap::directionsUser($CardCode);
            
            $buissness = [];
            $destination = [];
                        
            foreach($result as $key => $address){
                $result[$key]['AdresType'] = iconv("ISO-8859-1","UTF-8",$address['AdresType']);
                $result[$key]['Street'] = iconv("ISO-8859-1","UTF-8",$address['Street']);
                $result[$key]['Block'] = iconv("ISO-8859-1","UTF-8",$address['Block']);
                $result[$key]['City'] = iconv("ISO-8859-1","UTF-8",$address['City']);
                $result[$key]['Country'] = iconv("ISO-8859-1","UTF-8",$address['Country']);
                $result[$key]['State'] = iconv("ISO-8859-1","UTF-8",$address['State']);
                if($address['AdresType'] === "B") $buissness[] = $result[$key];
                if($address['AdresType'] === "S") $destination[] = $result[$key];
            }

            $dsn = null;
            $stmt = null;
            message('message', array("buissness" => $buissness, "destination" => $destination));
         }
         catch (Exception $e) {
            messageErrorCode($e->getMessage(),200);
         }
    }
}