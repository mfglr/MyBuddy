import { Component, Input } from '@angular/core';
import { PostComponent } from "../post-component/post-component";
import { Post } from '../../models/post';

@Component({
  selector: 'app-post-list-component',
  imports: [PostComponent],
  templateUrl: './post-list-component.html',
  styleUrl: './post-list-component.scss',
})
export class PostListComponent {
  @Input() posts: Post[] = [];
}
