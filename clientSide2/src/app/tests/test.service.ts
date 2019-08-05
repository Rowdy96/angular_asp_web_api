import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Test } from '../shared/Test';

@Injectable({
  providedIn: 'root'
})
export class TestService {

  private testUrl = " https://localhost:44357/";
  private _http : HttpClient;

  constructor(http : HttpClient) {
    this._http=http;
  }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  getAllTest():Observable<Test[]>{
    
    return this._http.get<Test[]>(this.testUrl+"api/Tests");
                      
  }

  getTestById(id : number):Observable<Test>{
    
    return this._http.get<Test>(this.testUrl+"api/Tests/" + id);
  }

  AddNewTest(test : Test): Observable<Test>{
    return this._http.post<Test>("https://localhost:44357/api/Tests",test);
  }

  DeleteTest(id : number):Observable<{}>{
   
    const url = "https://localhost:44357/api/Tests/"+id;
    debugger;
    return this._http.delete(url);
  }


}
