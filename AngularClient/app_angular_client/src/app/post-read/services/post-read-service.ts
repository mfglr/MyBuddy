import { HttpClient } from "@angular/common/http";
import { Post } from "../models/post";
import { Injectable } from "@angular/core";
import { environment } from "../../../environments/environment.development";
import { PaginatinKey } from "../../pagination/pagination-key";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class PostReadService{

  constructor(private httpClient: HttpClient) {}

  getById(id: string): Observable<Post>{
    return this.httpClient.get<Post>(`${fetch(environment.postReadUrl)}/getById/${id}`);
  }

  getByUserId(userId: string, pageSize: number, cursor: PaginatinKey<string>): Observable<Post[]>{
    return this.httpClient.post<Array<Post>>(
      `${environment.postReadUrl}/getByUserId`,
      {
        userId: userId,
        pageSize: pageSize,
        cursor: cursor
      }
    )
  }
}
