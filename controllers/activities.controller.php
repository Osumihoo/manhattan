<?php

class ControllerActivities {
    public function create($fields){
        try {           
            $response = [];
            $startcall =  date("Y-m-d H:i:s", strtotime($fields->startcall));
            $finishcall =  date("Y-m-d H:i:s", strtotime($fields->finishcall));

            $status = ModelActivities::create($fields,$startcall,$finishcall);

            if($status['status'] == 'success'){
                message('message','Actividad creada correctamente');
            }
         }
         catch (Exception $e) {
            messageErrorCode($e->getMessage(),200);
         }
    }

    public function put($fields){
        try {           
            $status = ModelActivities::put($fields);

            if($status['status'] == 'success'){
                message('message','Actividad actualizada correctamente');
            }
         }
         catch (Exception $e) {
            messageErrorCode($e->getMessage(),200);
         }
    }    
}