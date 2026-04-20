import { Component, Input } from '@angular/core';
import { MediaCircular } from "../../../media-circular/media-circular";

@Component({
  selector: 'app-comment-component',
  imports: [MediaCircular],
  templateUrl: './comment-component.html',
  styleUrl: './comment-component.scss',
})
export class CommentComponent {
  @Input() comment!: Comment
}
