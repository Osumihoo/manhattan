<?php

class ControllerServiceLayer {
    public function querys($fields){

        try {
            if(!isset($fields->url)) messageErrorCode("The *url* field is incorrect",200);
            if(!isset($fields->method)) messageErrorCode("The *method* field is incorrect",200);
            if(!isset($fields->body)) messageErrorCode("The *body* field is incorrect",200);
            
            $cliente = curl_init();
            curl_setopt($cliente,CURLOPT_HTTPHEADER,array('Content-Type: application/json','Accept: application/json'));
            curl_setopt($cliente, CURLOPT_URL, "{$_ENV['SERVICES_URL']}Login");
            curl_setopt($cliente, CURLOPT_POST, true);
            curl_setopt($cliente, CURLOPT_POSTFIELDS, json_encode(array(
                "CompanyDB"=>"{$_ENV['SERVICES_COMPANY']}",
                'Password'=>"{$_ENV['SERVICES_PASSWORD']}",
                'UserName'=>"{$_ENV['SERVICES_USERNAME']}",
                "Language"=>"25"
            )));
            curl_setopt($cliente, CURLOPT_RETURNTRANSFER, true);
            $login = curl_exec($cliente);
            curl_close($cliente);
            $login = json_decode($login);
            
            if($fields->method == 'GET') {
                $cliente = curl_init();
                curl_setopt($cliente,CURLOPT_HTTPHEADER,array('Content-Type: application/json',"cookie: B1SESSION={$login->SessionId}"));
                curl_setopt($cliente, CURLOPT_URL, "{$_ENV['SERVICES_URL']}{$fields->url}");
                // curl_setopt($cliente, CURLOPT_POST, true);
                // curl_setopt($cliente, CURLOPT_POSTFIELDS, json_encode($fields->body));
                curl_setopt($cliente, CURLOPT_RETURNTRANSFER, true);
                $response = curl_exec($cliente);
                curl_close($cliente);
                $response = json_decode($response);
                
                if(isset($response->error)){
                    messageErrorCode($response->error->message->value,200);
                }
            }

            if($fields->method == 'POST') {
                $cliente = curl_init();
                curl_setopt($cliente,CURLOPT_HTTPHEADER,array('Content-Type: application/json',"cookie: B1SESSION={$login->SessionId}"));
                curl_setopt($cliente, CURLOPT_URL, "{$_ENV['SERVICES_URL']}{$fields->url}");
                curl_setopt($cliente, CURLOPT_POST, true);
                curl_setopt($cliente, CURLOPT_POSTFIELDS, json_encode($fields->body));
                curl_setopt($cliente, CURLOPT_RETURNTRANSFER, true);
                $response = curl_exec($cliente);
                curl_close($cliente);
                $response = json_decode($response);

                if(isset($response->error)){
                    messageErrorCode($response->error->message->value,200);
                }
            }

            if($fields->method == 'PUT') {
                echo json_encode($fields->body);
                $cliente = curl_init();
                curl_setopt($cliente,CURLOPT_HTTPHEADER,array('Content-Type: application/json',"cookie: B1SESSION={$login->SessionId}"));
                curl_setopt($cliente, CURLOPT_URL, "{$_ENV['SERVICES_URL']}{$fields->url}");
                curl_setopt($cliente, CURLOPT_PUT, true);
                curl_setopt($cliente, CURLOPT_POSTFIELDS, json_encode($fields->body));
                curl_setopt($cliente, CURLOPT_RETURNTRANSFER, true);
                $response = curl_exec($cliente);
                curl_close($cliente);
                $response = json_decode($response);
                
                if(isset($response->error)){
                    messageErrorCode($response->error->message->value,200);
                }
            }

            if($fields->method == 'PATCH') {
                $cliente = curl_init();
                curl_setopt($cliente,CURLOPT_HTTPHEADER,array('Content-Type: application/json',"cookie: B1SESSION={$login->SessionId}"));
                curl_setopt($cliente, CURLOPT_URL, "{$_ENV['SERVICES_URL']}{$fields->url}");
                // curl_setopt($cliente, CURLOPT_PUT, true);
                curl_setopt($cliente, CURLOPT_CUSTOMREQUEST, 'PATCH');
                curl_setopt($cliente, CURLOPT_POSTFIELDS, json_encode($fields->body));
                curl_setopt($cliente, CURLOPT_RETURNTRANSFER, true);
                $response = curl_exec($cliente);
                curl_close($cliente);
                $response = json_decode($response);
                
                if(isset($response->error)){
                    messageErrorCode($response->error->message->value,200);
                }
            }
                            
            return $response;
         }
         catch (Exception $e) {
            messageErrorCode($e->getMessage(),200);
         }
    }

    public function querysApproval($fields){
        try {
            if(!isset($fields->url)) messageErrorCode("The *url* field is incorrect",200);
            if(!isset($fields->method)) messageErrorCode("The *method* field is incorrect",200);
            if(!isset($fields->body)) messageErrorCode("The *body* field is incorrect",200);
            
            $cliente = curl_init();
            curl_setopt($cliente,CURLOPT_HTTPHEADER,array('Content-Type: application/json','Accept: application/json'));
            curl_setopt($cliente, CURLOPT_URL, "{$_ENV['SERVICES_URL']}Login");
            curl_setopt($cliente, CURLOPT_POST, true);
            curl_setopt($cliente, CURLOPT_POSTFIELDS, json_encode(array(
                "CompanyDB"=>"{$_ENV['SERVICES_COMPANY']}",
                'Password'=>"{$_ENV['SERVICES_PASSWORD']}",
                'UserName'=>"{$_ENV['SERVICES_USERNAME']}",
                "Language"=>"25"
            )));
            curl_setopt($cliente, CURLOPT_RETURNTRANSFER, true);
            $login = curl_exec($cliente);
            curl_close($cliente);
            $login = json_decode($login);
 
            if($fields->method == 'POST') {
                $cliente = curl_init();
                curl_setopt($cliente,CURLOPT_HTTPHEADER,array('Content-Type: application/json',"cookie: B1SESSION={$login->SessionId}"));
                curl_setopt($cliente, CURLOPT_URL, "{$_ENV['SERVICES_URL']}{$fields->url}");
                curl_setopt($cliente, CURLOPT_POST, true);
                curl_setopt($cliente, CURLOPT_POSTFIELDS, json_encode($fields->body));
                curl_setopt($cliente, CURLOPT_RETURNTRANSFER, true);
                $response = curl_exec($cliente);
                curl_close($cliente);
                $response = json_decode($response);
            }   
            
            return $response;
         }
         catch (Exception $e) {
            messageErrorCode($e->getMessage(),200);
         }
    }
}