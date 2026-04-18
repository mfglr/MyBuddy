import { Component, Input } from '@angular/core';
import { ExtendableContentComponent } from '../../../extendable-content-component/extendable-content-component';
import { Post } from '../../models/post';

@Component({
  selector: 'app-post-content-component',
  imports: [
    ExtendableContentComponent
  ],
  templateUrl: './post-content-component.html',
  styleUrl: './post-content-component.scss',
})
export class PostContentComponent {
  @Input() post!: Post;
  extended: boolean = false;

  update(){
    this.extended = !this.extended;
  }
}
