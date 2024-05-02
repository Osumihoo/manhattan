<?php

class ControllerRoutes{
    static public function env(){
        $dotenv = Dotenv\Dotenv::createImmutable('./');
        $dotenv->load();
    }

    public function index(){
        include "routes/route.php";
    }

}