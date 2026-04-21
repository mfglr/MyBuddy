import { Component, OnInit, signal } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { Observable } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { PaginatinKey } from './pagination/pagination-key';
import { CommentService } from './comment-read/services/comment-service';
import { Comment } from './comment-read/models/comment';
import { CommentListComponent } from './comment-read/components/comment-list-component/comment-list-component';

@Component({
  selector: 'app-root',
  imports: [
    ReactiveFormsModule,
    AsyncPipe,
    CommentListComponent
],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App{
  comments$: Observable<Comment[]>;
  constructor(private commentService: CommentService) {
    this.comments$ = commentService.getByPostId("019dac6f-a014-792a-9057-f8ad30b72ba5", 20, new PaginatinKey<string>(true));
  }

  protected readonly title = signal('app_angular_client');
}
