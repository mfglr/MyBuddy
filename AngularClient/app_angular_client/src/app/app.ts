import { Component, OnInit, signal } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { Post } from './post-read/models/post';
import { PostReadService } from './post-read/services/post-read-service';
import { Observable } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { PostComponent } from './post-read/components/post-component/post-component';
import { PaginatinKey } from './pagination/pagination-key';

@Component({
  selector: 'app-root',
  imports: [
    ReactiveFormsModule,
    PostComponent,
    AsyncPipe
],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App implements OnInit {

  posts$: Observable<Post[]>;
  constructor(private postService: PostReadService) {
    this.posts$ = postService.getByUserId("019da20a-95cb-79f7-9fb5-d97b96445051",20,new PaginatinKey<string>(true))
  }

  ngOnInit(): void {
  }

  // onFiles(event: Event){
  //   const input = event.target as HTMLInputElement;
  //   if (!input.files || input.files.length === 0) return;

  //   let media: LocalMedia[] = [];
  //   for(let i = 0; i < input.files.length; i++){
  //     media[i] = new LocalMedia(input.files[i])
  //   }
  //   this.media = [
  //     ...this.media,
  //     ...media
  //   ];
  // }

  protected readonly title = signal('app_angular_client');
}
