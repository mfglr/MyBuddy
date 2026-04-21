import { Component, Input } from '@angular/core';
import { CommentComponent } from "../comment-component/comment-component";
import { Comment } from '../../models/comment';

@Component({
  selector: 'app-comment-list-component',
  imports: [CommentComponent],
  templateUrl: './comment-list-component.html',
  styleUrl: './comment-list-component.scss',
})
export class CommentListComponent {
  @Input() comments: Comment[] = [];
  @Input() bottomMargin: number = 15;
}
