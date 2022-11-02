import { Injectable } from '@angular/core';
import { ApiconstantService } from '../helpers/httpConstant';
import { HttpmoduleService } from '../helpers/httpmodule.service';

@Injectable({
  providedIn: 'root'
})
export class DataserviceService {
 
  constructor(private httpHelper: HttpmoduleService,
    private apiUrl: ApiconstantService) { }

   
      GetemployeePaging(command:
        any)
      {    
        return this.httpHelper.apiPost(this.apiUrl.endpoint+"employee-list",command)
        
  


    }
}
