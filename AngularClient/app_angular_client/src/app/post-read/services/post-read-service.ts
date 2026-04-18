import { HttpClient } from "@angular/common/http";
import { Post } from "../models/post";
import { Injectable } from "@angular/core";


@Injectable({
  providedIn: "root"
})
export class PostReadService{

  constructor(private httpClient: HttpClient) {
  }

  getById(id: string){
    return this.httpClient.get<Post>(`http://localhost:5024/api/v1/posts/getById/${id}`);
  }
}
