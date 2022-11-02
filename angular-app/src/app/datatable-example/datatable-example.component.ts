import { Component, OnInit } from '@angular/core';
import { GetProfileBase64 } from '../helpers/utils';
import { DataserviceService } from './dataservice.service';
import * as bootstrap from 'bootstrap';
declare var window: any;
@Component({
  selector: 'app-datatable-example',
  templateUrl: './datatable-example.component.html',
  styleUrls: ['./datatable-example.component.css']
})
export class DatatableExampleComponent implements OnInit {
  emplIst: any;
  dtOptions: any = {};
  showTable: boolean = true;
  formModal: any;
  selectedUser:any; 
  modalName: bootstrap.Modal | undefined;  
  constructor(
    private dataService: DataserviceService
  ) {


  }

  ngOnInit(): void {

    this.loadData();
  }

  getProfileImage(image: any) {
    if (image == "" || image == null) {

      return GetProfileBase64();
    }
    else {
      return image;
    }
  }
  loadData() {
    this.dtOptions = {
      pagingType: "full_numbers",
      pageLength: 10,
      serverSide: true,
      processing: true,
      searching: true,
      responsive: true,
      ajax: (dataTablesParameters: any, callback: any) => {
        this.dataService
          .GetemployeePaging(dataTablesParameters)
          .subscribe((resp) => {
            this.emplIst = resp.serchData;
            callback({
              recordsTotal: resp.recordsTotal,
              recordsFiltered: resp.recordsFiltered,

              data: [],
            });
          });

      },
    };
  }

  reload() {
    this.showTable = false;
    this.loadData();
    setTimeout(() => {
      this.showTable = true;
    }, 0);
  }
  editEmployee(element: any, user: any) {   
    this.selectedUser=user; // you can replace as per  
    this.formModal = new bootstrap.Modal(element, {})
    this.formModal?.show()
    this.reload(); // call to refresh your datatable
  }
  

}
