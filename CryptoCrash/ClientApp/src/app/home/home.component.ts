import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  articleList =[];
  constructor(private http: HttpClient){
    this.handleRetrieveData();
  }

  handleRetrieveData(){
    this.http.get("https://newsapi.org/v2/everything?q=cryptocurrency&apiKey=D08d6b3c579542f0abbae1f6a3c3949a").subscribe((data:any)=>{
      console.log("data", data);
      this.articleList = data.articles;
      console.log(this.articleList);
      console.log('title',this.articleList[0]['title']);
      
      console.log("this.articleList",this.articleList);
    })
  }
}

