<?php
$arrayRoute = explode('/',$_SERVER['REQUEST_URI']);

/*=============================================
Validamos el origen de la peticion y traemos el compañia que hace el movimiento
=============================================*/
$headers = new HeadersController();
$userAuth = $headers->token();

/*=============================================
Orden de venta
=============================================*/
if(count(array_filter($arrayRoute)) > 1 && array_filter($arrayRoute)[2] == "sales") {
    switch($_SERVER['REQUEST_METHOD']){       
        case 'POST':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            $sales = new ControllerSales();
            $sales->createSales($fields);
            break;

        case 'PATCH':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            $sales = new ControllerSales();
            $sales->createSales($fields);
        break;

        default:
            messageErrorCode('Method Not Allowed',200);
    }

    return;
}

if(count(array_filter($arrayRoute)) > 1 && explode('?',array_filter($arrayRoute)[2])[0] == "sales") {
    switch($_SERVER['REQUEST_METHOD']){
        case 'GET':
                if(!isset($_GET['type'])) messageErrorCode("The *type* field is incorrect",200);
                $type = $_GET['type'];
                
                $offer = new ControllerSales();
                if($type == 'client'){
                    $offer->showUser();
                }
                if($type == 'direction'){
                    if(!isset($_GET['cardcode'])) messageErrorCode("The *cardcode* field is incorrect",200);
                    $cardcode = $_GET['cardcode'];
                    $offer->showDirection($cardcode);
                } 
                if($type == 'sap'){
                    $offer->informationSAP();
                } 
                if($type == 'products'){
                    if(!isset($_GET['pricelist'])) messageErrorCode("The *pricelist* field is incorrect",200);
                    if(!isset($_GET['warehouse'])) messageErrorCode("The *warehouse* field is incorrect",200);
                    $offer->productSAP($_GET['pricelist'],$_GET['warehouse']);
                } 
                if($type == 'alloffer'){
                    if(!isset($_GET['start'])) messageErrorCode("The *start* field is incorrect",200);
                    if(!isset($_GET['finish'])) messageErrorCode("The *finish* field is incorrect",200);
                    if(!isset($_GET['salePerson'])) messageErrorCode("The *finish* field is incorrect",200);
                    $offer->alloffer($_GET['start'],$_GET['finish'],$_GET['salePerson']);
                } 
                if($type == 'offer'){
                    if(!isset($_GET['DocEntry'])) messageErrorCode("The *DocEntry* field is incorrect",200);
                    $offer->offer($_GET['DocEntry']);
                } 
            break;
        
        case 'POST':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            break;

        default:
            messageErrorCode('Method Not Allowed',200);
    }

    return;
}

/*=============================================
Orden de compra
=============================================*/
if(count(array_filter($arrayRoute)) > 1 && array_filter($arrayRoute)[2] == "createshop") {
    switch($_SERVER['REQUEST_METHOD']){       
        case 'POST':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            $offer = new ControllerShop();
            $offer->createShopOffer($fields);
            break;
        
        case 'PATCH':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            $offer = new ControllerShop();
            $offer->updateShopOffer($fields);
            break;

        case 'DELETE':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            $offer = new ControllerShop();
            $offer->deleteShopOffer($fields);
            break;
        default:
            messageErrorCode('Method Not Allowed',200);
    }

    return;
}

if(count(array_filter($arrayRoute)) > 1 && explode('?',array_filter($arrayRoute)[2])[0] == "createshop") {
    switch($_SERVER['REQUEST_METHOD']){
        case 'GET':
                if(!isset($_GET['type'])) messageErrorCode("The *type* field is incorrect",200);
                $type = $_GET['type'];
                
                $offer = new Controllershop();
                if($type == 'provider'){
                    $offer->supplier();
                }
                if($type == 'direction'){
                    $offer->showDirection();
                } 
                if($type == 'sap'){
                    $offer->informationSAP();
                } 
                if($type == 'products'){
                    if(!isset($_GET['pricelist'])) messageErrorCode("The *pricelist* field is incorrect",200);
                    if(!isset($_GET['warehouse'])) messageErrorCode("The *warehouse* field is incorrect",200);
                    if(!isset($_GET['cardcode'])) messageErrorCode("The *cardcode* field is incorrect",200);
                    $offer->productSAP($_GET['pricelist'],$_GET['warehouse'],$_GET['cardcode']);
                } 
                if($type == 'alloffer'){
                    if(!isset($_GET['start'])) messageErrorCode("The *start* field is incorrect",200);
                    if(!isset($_GET['finish'])) messageErrorCode("The *finish* field is incorrect",200);
                    if(!isset($_GET['salePerson'])) messageErrorCode("The *finish* field is incorrect",200);
                    $offer->alloffer($_GET['start'],$_GET['finish'],$_GET['salePerson']);
                } 
                if($type == 'offer'){
                    if(!isset($_GET['DocEntry'])) messageErrorCode("The *DocEntry* field is incorrect",200);
                    $offer->offer($_GET['DocEntry']);
                } 
            break;
        
        case 'POST':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            break;

        default:
            messageErrorCode('Method Not Allowed',200);
    }

    return;
}

/*=============================================
Ofertas de compra
=============================================*/
if(count(array_filter($arrayRoute)) > 1 && array_filter($arrayRoute)[2] == "createshopoffer") {
    switch($_SERVER['REQUEST_METHOD']){       
        case 'POST':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            $offer = new ControllerShopOffer();
            $offer->createShopOffer($fields);
            break;
        
        case 'PATCH':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            $offer = new ControllerShopOffer();
            $offer->updateShopOffer($fields);
            break;
        default:
            messageErrorCode('Method Not Allowed',200);
    }

    return;
}

if(count(array_filter($arrayRoute)) > 1 && explode('?',array_filter($arrayRoute)[2])[0] == "createshopoffer") {
    switch($_SERVER['REQUEST_METHOD']){
        case 'GET':
                if(!isset($_GET['type'])) messageErrorCode("The *type* field is incorrect",200);
                $type = $_GET['type'];
                
                $offer = new ControllershopOffer();
                if($type == 'provider'){
                    $offer->supplier();
                }
                if($type == 'direction'){
                    $offer->showDirection();
                } 
                if($type == 'sap'){
                    $offer->informationSAP();
                } 
                if($type == 'products'){
                    if(!isset($_GET['pricelist'])) messageErrorCode("The *pricelist* field is incorrect",200);
                    if(!isset($_GET['warehouse'])) messageErrorCode("The *warehouse* field is incorrect",200);
                    if(!isset($_GET['cardcode'])) messageErrorCode("The *cardcode* field is incorrect",200);
                    $offer->productSAP($_GET['pricelist'],$_GET['warehouse'],$_GET['cardcode']);
                } 
                if($type == 'alloffer'){
                    if(!isset($_GET['start'])) messageErrorCode("The *start* field is incorrect",200);
                    if(!isset($_GET['finish'])) messageErrorCode("The *finish* field is incorrect",200);
                    if(!isset($_GET['salePerson'])) messageErrorCode("The *finish* field is incorrect",200);
                    $offer->alloffer($_GET['start'],$_GET['finish'],$_GET['salePerson']);
                } 
                if($type == 'offer'){
                    if(!isset($_GET['DocEntry'])) messageErrorCode("The *DocEntry* field is incorrect",200);
                    $offer->offer($_GET['DocEntry']);
                } 
            break;
        
        case 'POST':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            break;

        default:
            messageErrorCode('Method Not Allowed',200);
    }

    return;
}


/*=============================================
Proceso de aprobacion
=============================================*/
if(count(array_filter($arrayRoute)) > 1 && array_filter($arrayRoute)[2] == "approval") {
    switch($_SERVER['REQUEST_METHOD']){       
        case 'POST':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            $offer = new ControllerOffer();
            $offer->createOffer($fields);
            break;

        case 'PATCH':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            $offer = new ControllerOffer();
            $offer->updateOffer($fields);
        break;

        default:
            messageErrorCode('Method Not Allowed',200);
    }

    return;
}


if(count(array_filter($arrayRoute)) > 1 && explode('?',array_filter($arrayRoute)[2])[0] == "approval") {
    switch($_SERVER['REQUEST_METHOD']){
        case 'GET':
                if(!isset($_GET['type'])) messageErrorCode("The *type* field is incorrect",200);
                $type = $_GET['type'];
            
                
                $approval = new ControllerApproval();
                if($type == 'client'){
                    $approval->showUser();
                }
                if($type == 'direction'){
                    if(!isset($_GET['cardcode'])) messageErrorCode("The *cardcode* field is incorrect",200);
                    $cardcode = $_GET['cardcode'];
                    $approval->showDirection($cardcode);
                } 
                if($type == 'sap'){
                    $approval->informationSAP();
                } 
                if($type == 'products'){
                    if(!isset($_GET['pricelist'])) messageErrorCode("The *pricelist* field is incorrect",200);
                    if(!isset($_GET['warehouse'])) messageErrorCode("The *warehouse* field is incorrect",200);
                    $approval->productSAP($_GET['pricelist'],$_GET['warehouse']);
                } 
                if($type == 'alloffer'){
                    if(!isset($_GET['start'])) messageErrorCode("The *start* field is incorrect",200);
                    if(!isset($_GET['finish'])) messageErrorCode("The *finish* field is incorrect",200);
                    if(!isset($_GET['salePerson'])) messageErrorCode("The *finish* field is incorrect",200);
                    $approval->alloffer($_GET['start'],$_GET['finish'],$_GET['salePerson']);
                } 
                if($type == 'offer'){
                    if(!isset($_GET['DocEntry'])) messageErrorCode("The *DocEntry* field is incorrect",200);
                    $approval->offer($_GET['DocEntry']);
                }
                if($type == 'createToDraft'){
                    if(!isset($_GET['DocEntry'])) messageErrorCode("The *DocEntry* field is incorrect",200);
                    $approval->createToDraft($_GET['DocEntry']);
                }  
            break;
        
        case 'POST':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            break;

        default:
            messageErrorCode('Method Not Allowed',200);
    }

    return;
}

/*=============================================
Ofertas de ventas
=============================================*/
if(count(array_filter($arrayRoute)) > 1 && array_filter($arrayRoute)[2] == "createoffer") {
    switch($_SERVER['REQUEST_METHOD']){       
        case 'POST':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            $offer = new ControllerOffer();
            $offer->createOffer($fields);
            break;

        case 'PATCH':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            $offer = new ControllerOffer();
            $offer->updateOffer($fields);
        break;

        default:
            messageErrorCode('Method Not Allowed',200);
    }

    return;
}

if(count(array_filter($arrayRoute)) > 1 && array_filter($arrayRoute)[2] == "offertosale") {
    switch($_SERVER['REQUEST_METHOD']){       
        case 'POST':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            $offer = new ControllerOffer();
            $offer->createOfferToSale($fields);
            break;

        case 'PATCH':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            $offer = new ControllerOffer();
            $offer->updateOffer($fields);
        break;

        default:
            messageErrorCode('Method Not Allowed',200);
    }

    return;
}

if(count(array_filter($arrayRoute)) > 1 && explode('?',array_filter($arrayRoute)[2])[0] == "createoffer") {
    switch($_SERVER['REQUEST_METHOD']){
        case 'GET':
                if(!isset($_GET['type'])) messageErrorCode("The *type* field is incorrect",200);
                $type = $_GET['type'];
                
                $offer = new ControllerOffer();
                if($type == 'client'){
                    $offer->showUser();
                }
                if($type == 'direction'){
                    if(!isset($_GET['cardcode'])) messageErrorCode("The *cardcode* field is incorrect",200);
                    $cardcode = $_GET['cardcode'];
                    $offer->showDirection($cardcode);
                } 
                if($type == 'sap'){
                    $offer->informationSAP();
                } 
                if($type == 'products'){
                    if(!isset($_GET['pricelist'])) messageErrorCode("The *pricelist* field is incorrect",200);
                    if(!isset($_GET['warehouse'])) messageErrorCode("The *warehouse* field is incorrect",200);
                    $offer->productSAP($_GET['pricelist'],$_GET['warehouse']);
                } 
                if($type == 'alloffer'){
                    if(!isset($_GET['start'])) messageErrorCode("The *start* field is incorrect",200);
                    if(!isset($_GET['finish'])) messageErrorCode("The *finish* field is incorrect",200);
                    if(!isset($_GET['salePerson'])) messageErrorCode("The *finish* field is incorrect",200);
                    $offer->alloffer($_GET['start'],$_GET['finish'],$_GET['salePerson']);
                } 
                if($type == 'offer'){
                    if(!isset($_GET['DocEntry'])) messageErrorCode("The *DocEntry* field is incorrect",200);
                    $offer->offer($_GET['DocEntry']);
                } 
            break;
        
        case 'POST':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            break;

        default:
            messageErrorCode('Method Not Allowed',200);
    }

    return;
}


/*=============================================
Historico
=============================================*/
if(count(array_filter($arrayRoute)) > 1 && array_filter($arrayRoute)[2] == "history") {
    switch($_SERVER['REQUEST_METHOD']){
        case 'GET':
                $history = new ControllerHistory();
                $history->show();
            break;

        default:
            messageErrorCode('Method Not Allowed',200);
    }

    return;
}

/*=============================================
Sincronizador
=============================================*/
if(count(array_filter($arrayRoute)) > 1 && array_filter($arrayRoute)[2] == "syncclients") {
    switch($_SERVER['REQUEST_METHOD']){
        case 'GET':
                $sync = new ControllerSyncClient();
                $sync->clients();
            break;

        default:
            messageErrorCode('Method Not Allowed',200);
    }

    return;
}

/*=============================================
CRUD Actividades
=============================================*/
if(count(array_filter($arrayRoute)) > 1 && array_filter($arrayRoute)[2] == "activities") {
    switch($_SERVER['REQUEST_METHOD']){
        case 'POST':
                if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
                $fields = json_decode($fields);
                if(!isset($fields->type)) messageErrorCode("The *type* field is incorrect",200);
                $activities = new ControllerActivities();
                $type = $fields->type;
                // if($type == 'call'){
                //     $activities->updateCall($fields);
                //     exit;
                // }
                if($type == 'create'){
                    $activities->create($fields);
                    exit;
                }
            break;
        case 'PUT':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            $activities = new ControllerActivities();
            $activities->put($fields);
            exit;
            break;
        case 'DELETE':
            exit;
            break;

        default:
            messageErrorCode('Method Not Allowed',200);
    }

    return;
}

/*=============================================
RAZONES DE INCIDENCIA
=============================================*/
if(count(array_filter($arrayRoute)) > 1 && explode('?',array_filter($arrayRoute)[2])[0] == "reason") {
    switch($_SERVER['REQUEST_METHOD']){
        case 'GET':
                if(!isset($_GET['type'])){
                    messageErrorCode("The *type* field is incorrect",200);
                }
                $type = $_GET['type'];

                if($type == 'all'){
                    $clients = new ControllerReason();
                    $clients->allsReason();
                }
            break;

        default:
            messageErrorCode('Method Not Allowed',200);
    }

    return;
}

/*=============================================
CONSULTAS SAP
=============================================*/
if(count(array_filter($arrayRoute)) > 1 && explode('?',array_filter($arrayRoute)[2])[0] == "sap") {
    switch($_SERVER['REQUEST_METHOD']){
        case 'GET':
                if(!isset($_GET['type'])){
                    messageErrorCode("The *type* field is incorrect",200);
                }
                $type = $_GET['type'];

                if($type == 'bills'){
                    $start = $_GET['start'];
                    $finish = $_GET['finish'];
                    $clients = new ControllerSap();
                    $clients->bills($start,$finish);
                }
                if($type == 'allInvoices'){
                    $cardcode = $_GET['cardcode'];
                    $start = $_GET['start'];
                    $finish = $_GET['finish'];
                    $clients = new ControllerSap();
                    $clients->allInvoices($cardcode,$start,$finish);
                }
                if($type == 'detailInvoices'){
                    $docnum = $_GET['docnum'];
                    $clients = new ControllerSap();
                    $clients->detailInvoices($docnum);
                }
                if($type == 'directionsUser'){
                    $cardcode = $_GET['cardcode'];
                    $clients = new ControllerSap();
                    $clients->directionsUser($cardcode);
                }
            break;

        default:
            messageErrorCode('Method Not Allowed',200);
    }

    return;
}

/*=============================================
Lista de cliente
=============================================*/
if(count(array_filter($arrayRoute)) > 1 && array_filter($arrayRoute)[2] == "aclients") {
    switch($_SERVER['REQUEST_METHOD']){
        case 'GET':
                $clients = new ControllerClients();
                $clients->showArray();
            break;
        default:
            messageErrorCode('Method Not Allowed',200);
    }

    return;
}

/*=============================================
CRUD usuarios
=============================================*/
if(count(array_filter($arrayRoute)) > 1 && array_filter($arrayRoute)[2] == "clients") {
    switch($_SERVER['REQUEST_METHOD']){
        case 'GET':
                if(count(array_filter($arrayRoute)) > 2 && is_numeric(array_filter($arrayRoute)[3])){
                    $clients = new ControllerClients();
                    $clients->show(array_filter($arrayRoute)[3]);
                }else{
                    $clients = new ControllerClients();
                    $clients->show(null);
                }
            break;
        case 'POST':
                if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
                $fields = json_decode($fields);
                $clients = new ControllerClients();
                $clients->create($fields);
            break;
        case 'PUT':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            $clients = new ControllerClients();
            $clients->put($fields);
        break;
        case 'DELETE':
                if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
                $fields = json_decode($fields);
                $clients = new ControllerClients();
                $clients->delete($fields->id, $fields->status);
            break;

        default:
            messageErrorCode('Method Not Allowed',200);
    }

    return;
}

/*=============================================
Login
=============================================*/
if(count(array_filter($arrayRoute)) > 1 && array_filter($arrayRoute)[2] == "login") {
    switch($_SERVER['REQUEST_METHOD']){
        case 'POST':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
                $fields = json_decode($fields);
                $login = new ControllerLogin();
                $login->validar($fields);
            return;
            break;
        default:
            messageErrorCode('Method Not Allowed',200);
    }
}

/*=============================================
CRUD usuarios
=============================================*/
if(count(array_filter($arrayRoute)) > 1 && array_filter($arrayRoute)[2] == "employer") {
    switch($_SERVER['REQUEST_METHOD']){
        case 'GET':
                if(count(array_filter($arrayRoute)) > 2 && is_numeric(array_filter($arrayRoute)[3])){
                    $employer = new ControllerEmployers();
                    $employer->show(array_filter($arrayRoute)[3]);
                }else{
                    $employer = new ControllerEmployers();
                    $employer->show(null);
                }
            break;
        case 'POST':
                if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
                $fields = json_decode($fields);
                $employer = new ControllerEmployers();
                $employer->create($fields);
            break;
        case 'PUT':
            if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
            $fields = json_decode($fields);
            $employer = new ControllerEmployers();
            $employer->put($fields);
        break;
        case 'DELETE':
                if (!$fields = file_get_contents('php://input')) return messageErrorCode('incomplete petition request', 400);
                $fields = json_decode($fields);
                $employer = new ControllerEmployers();
                $employer->delete($fields->id, $fields->status);
            break;

        default:
            messageErrorCode('Method Not Allowed',200);
    }

    return;
}

/*=============================================
Info SAP usuarios
=============================================*/
if(count(array_filter($arrayRoute)) > 1 && explode('?',array_filter($arrayRoute)[2])[0] == "employer") {
    switch($_SERVER['REQUEST_METHOD']){
        case 'GET':
            if(!isset($_GET['type'])) messageErrorCode('The *type* field is incorrect',200);
            $type = $_GET['type'];

            if($type == 'user'){
                $employer = new ControllerEmployers();
                $employer->showUsersSap();
            }
                // if(count(array_filter($arrayRoute)) > 2 && is_numeric(array_filter($arrayRoute)[3])){
                //     $clients = new ControllerClients();
                //     $clients->show(array_filter($arrayRoute)[3]);
                // }else{
                // }
            break;

        default:
            messageErrorCode('Method Not Allowed',200);
    }

    return;
}

/*=============================================
HOME API
=============================================*/
message("message",
array("message"=>"Consulta con el administrador el uso de la api",
        "version"=>$_ENV['VERSION'],
        "contact"=>$_ENV['ADMIN_CONTACT'],
        "whatsapp"=>$_ENV['ADMIN_WHATS'],
        "email"=>$_ENV['ADMIN_MAIL']
    ));
return;
