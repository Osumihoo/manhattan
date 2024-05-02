<?php
    function messageErrorCode($message, $code)
    {
        http_response_code($code);
        echo json_encode(array(
            "conflicts" => array(
                "problems" => true,
                "description" => $message,
            ),
        ));
        exit;
    }

    function message($response,$message){
        http_response_code(200);
        echo json_encode(array(
            $response => $message,
            "conflicts" => array(
                "problems" => false,
                "description" => "",
            ),
        ));
    }