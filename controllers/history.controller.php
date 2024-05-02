<?php

class ControllerHistory {
    public function show(){
        try {           
            $status = ModelHistory::show();
            message("message",$status);
         }
         catch (Exception $e) {
            messageErrorCode($e->getMessage(),200);
         }
    }
}