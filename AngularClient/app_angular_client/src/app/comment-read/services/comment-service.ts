import { HttpClient } from "@angular/common/http";
import { PaginatinKey } from "../../pagination/pagination-key";
import { Comment } from "../models/comment";
import { environment } from "../../../environments/environment.development";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class CommentService{

  constructor(private httpClient: HttpClient) {}

  getByPostId(postId: string, pageSize: number, cursor: PaginatinKey<string>): Observable<Comment[]>{
    return this.httpClient.post<Comment[]>(
      `${environment.commentReadUrl}/getByPostId`,
      {
        postId: postId,
        pageSize: pageSize,
        cursor: cursor
      }
    );
  }

  getByParentId(parentId: string, pageSize: number, cursor: PaginatinKey<string>): Observable<Comment[]>{
    return this.httpClient.post<Comment[]>(
      `${environment.commentReadUrl}/getByParentId`,
      {
        parentId: parentId,
        pageSize: pageSize,
        cursor: cursor
      }
    );
  }
}
