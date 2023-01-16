import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';
@Component({
  selector: 'app-show-delete-sub',
  templateUrl: './show-delete-sub.component.html',
  styleUrls: ['./show-delete-sub.component.css']
})
export class ShowDeleteSubComponent implements OnInit {

  constructor(private service:SharedService) { }

  SubjectData:any=[];

  ModalTitle:string;
  ActivateAddEditSubComp:boolean=false;
  sub:any;


  ngOnInit(): void {
    this.refreshDepList();
  }

  addClick(){
    this.sub={
      Name:0,
      Description:""
    }
    this.ModalTitle="Add Subject";
    this.ActivateAddEditSubComp=true;

  }

  editClick(item){
    this.sub=item;
    this.ModalTitle="Edit Subject";
    this.ActivateAddEditSubComp=true;
  }

  deleteClick(item){
    if(confirm('Are you sure??')){
      this.service.deleteSub(item.Name).subscribe(data=>{
        alert(data.toString());
        this.refreshDepList();
      })
    }
  }

  closeClick(){
    this.ActivateAddEditSubComp=false;
    this.refreshDepList();
  }


  refreshDepList(){
    this.service.getSubData().subscribe(data=>{
      this.SubjectData=data;
    });
  }

  // FilterFn(){
  //   var DepartmentIdFilter = this.DepartmentIdFilter;
  //   var DepartmentNameFilter = this.DepartmentNameFilter;

  //   this.DepartmentList = this.DepartmentListWithoutFilter.filter(function (el){
  //       return el.DepartmentId.toString().toLowerCase().includes(
  //         DepartmentIdFilter.toString().trim().toLowerCase()
  //       )&&
  //       el.DepartmentName.toString().toLowerCase().includes(
  //         DepartmentNameFilter.toString().trim().toLowerCase()
  //       )
  //   });
  // }

  // sortResult(prop,asc){
  //   this.DepartmentList = this.DepartmentListWithoutFilter.sort(function(a,b){
  //     if(asc){
  //         return (a[prop]>b[prop])?1 : ((a[prop]<b[prop]) ?-1 :0);
  //     }else{
  //       return (b[prop]>a[prop])?1 : ((b[prop]<a[prop]) ?-1 :0);
  //     }
  //   })
  // }

}
