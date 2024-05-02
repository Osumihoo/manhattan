<?php
if(isset($_SERVER["HTTP_ORIGIN"]))
{
    // You can decide if the origin in $_SERVER['HTTP_ORIGIN'] is something you want to allow, or as we do here, just allow all
    header("Access-Control-Allow-Origin: {$_SERVER['HTTP_ORIGIN']}");
}
else
{
    //No HTTP_ORIGIN set, so we allow any. You can disallow if needed here
    header("Access-Control-Allow-Origin: *");
}

header("Access-Control-Allow-Credentials: true");
header("Access-Control-Max-Age: 600");    // cache for 10 minutes

if($_SERVER["REQUEST_METHOD"] == "OPTIONS")
{
    if (isset($_SERVER["HTTP_ACCESS_CONTROL_REQUEST_METHOD"]))
        header("Access-Control-Allow-Methods: POST, GET, OPTIONS, DELETE, PUT, PATCH"); //Make sure you remove those you do not want to support

    if (isset($_SERVER["HTTP_ACCESS_CONTROL_REQUEST_HEADERS"]))
        header("Access-Control-Allow-Headers: {$_SERVER['HTTP_ACCESS_CONTROL_REQUEST_HEADERS']}");

    //Just exit with 200 OK with the above headers for OPTIONS method
    exit(0);
}

/*=============================================
Inicia los procesos de la api
=============================================*/
require_once "vendor/autoload.php";
require_once "controllers/routes.controller.php";
$route = new ControllerRoutes();
$route->env();

/*=============================================
functions
=============================================*/
require_once "functions/message.php";

/*=============================================
controllers
=============================================*/
require_once "controllers/encrypt.controller.php";
require_once "controllers/headers.controller.php";
require_once "controllers/employers.controller.php";
require_once "controllers/login.controller.php";
require_once "controllers/clients.controller.php";
require_once "controllers/sap.controller.php";
require_once "controllers/reason.controller.php";
require_once "controllers/activities.controller.php";
require_once "controllers/syncclient.controller.php";
require_once "controllers/history.controller.php";
require_once "controllers/offer.controller.php";
require_once "controllers/servicesLayer.controller.php";
require_once "controllers/shopoffer.controller.php";
require_once "controllers/shop.controller.php";
require_once "controllers/sales.controller.php";
require_once "controllers/approvalrequest.controller.php";
require_once "controllers/approval.controller.php";

/*=============================================
models
=============================================*/
require_once "models/headers.models.php";
require_once "models/employers.models.php";
require_once "models/login.models.php";
require_once "models/clients.models.php";
require_once "models/sap.models.php";
require_once "models/reason.models.php";
require_once "models/activities.models.php";
require_once "models/syncclient.models.php";
require_once "models/history.models.php";
require_once "models/offer.models.php";
require_once "models/servicesLayer.models.php";
require_once "models/shopoffer.models.php";
require_once "models/shop.models.php";
require_once "models/sales.php";
require_once "models/approvalrequest.models.php";
require_once "models/approval.models.php";

$route->index();