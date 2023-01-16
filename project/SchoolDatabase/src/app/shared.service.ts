import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl="http://localhost:5000/api";
  constructor(private http:HttpClient) { }

  getStData():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/student');
  }

  addSt(info:any){
    return this.http.post(this.APIUrl+'/student',info);
  }

  updateSt(info:any){
    return this.http.put(this.APIUrl+'/student',info);
  }

  deleteSt(info:any){
    return this.http.delete(this.APIUrl+'/student/'+info);
  }



  getSubData():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/subject');
  }

  addSub(info:any){
    return this.http.post(this.APIUrl+'/subject',info);
  }

  updateSub(info:any){
    return this.http.put(this.APIUrl+'/subject',info);
  }

  deleteSub(info:any){
    return this.http.delete(this.APIUrl+'/subject/'+info);
  }

}
