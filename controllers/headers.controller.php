<?php

class HeadersController{
    public function token(){        
        // if(!isset($_SERVER['HTTP_ORIGIN'])) messageErrorCode('Origen deconocido', 200);
        
        if (!isset(apache_request_headers()['Authorization'])) {
            messageErrorCode('Token authorization required', 401);
            exit;
        }
        
        $token =  apache_request_headers()['Authorization'];
        $userToken = HeadersModel::getHeaders($token);

        
        if(!sizeof($userToken)){
            messageErrorCode('Companie is incorrect, please check your credentials', 401);
        }
        
        $userToken = $userToken[0];

        if($userToken['enable'] != 1) {
            messageErrorCode('The company is disabled, please contact an administrator', 401);
        }
        
        return $userToken;
    }
}