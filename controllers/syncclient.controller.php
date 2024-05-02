<?php

class ControllerSyncClient {
    public function clients(){
        try {           
            $clients = ModelClients::show(null);
            $idsaps = "";

            foreach($clients as $client){
                $idsaps .= "'{$client['idsap']}'" . ",";
            }
            $idsaps = substr($idsaps,0,-1);
            $response = ModelSyncClient::showClients($idsaps);
            if(sizeof($response) == 0){
                message("message","no hay nuevos usuarios");
                exit;
            }
            $groups = ModelSyncClient::groups();
            $sales = ModelSyncClient::saleperson();

            foreach($response as $key => $current){
                $current['fullname'] = iconv("ISO-8859-1","UTF-8",$current['fullname']);
                $current['group'] = iconv("ISO-8859-1","UTF-8",$current['group']);
                $current['saleperson'] = iconv("ISO-8859-1","UTF-8",$current['saleperson']);
                $current['rfc'] = iconv("ISO-8859-1","UTF-8",$current['rfc']);
                $current['pharmacy'] = 1;
                
                $indexGroup = array_search($current['group'], array_column($groups, 'idsap'));
                $indexSale = array_search($current['saleperson'], array_column($sales, 'idsap'));
                $current['idgroup'] = $groups[$indexGroup]['id'];
                $current['idsaleperson'] = $sales[$indexSale]['id'];

                $isCreate = ModelSyncClient::create($current);
            }
            message("message","Usuarios sincronizados");
         }
         catch (Exception $e) {
            messageErrorCode($e->getMessage(),200);
         }
    }
}