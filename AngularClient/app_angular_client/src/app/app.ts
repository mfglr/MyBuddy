import { Component, OnInit, signal } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { Post } from './post-read/models/post';
import { PostReadService } from './post-read/services/post-read-service';
import { Observable } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { PostComponent } from './post-read/components/post-component/post-component';

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

  post$: Observable<Post>;
  constructor(private postService: PostReadService) {
    this.post$ = postService.getById("019da210-9e44-7185-af6c-afc1ab71902c")
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
