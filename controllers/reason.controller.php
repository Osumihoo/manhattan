<?php

class ControllerReason {
    public function allsReason(){
        try {           
            $activity = ModelReason::activityreason();
            $cancellation = ModelReason::cancellationreason();
            $incidents = ModelReason::incidentsreason();
            $status = ModelReason::statusreason();
            

            message("message",array("activity"=>$activity,"cancellation"=>$cancellation,"incidents"=>$incidents,"status"=>$status));
         }
         catch (Exception $e) {
            messageErrorCode($e->getMessage(),200);
         }
    }
}