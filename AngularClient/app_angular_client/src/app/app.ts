import { Component, signal } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { LocalMedia } from './media-core/local-media';
import { BaseMedia } from './media-core/base-media';
import { MediaType } from './media-core/media-type';
import { PostUserCardComponent } from './post-read/components/post-user-card-component/post-user-card-component';
import { Post } from './post-read/models/post';

@Component({
  selector: 'app-root',
  imports: [
    ReactiveFormsModule,
    PostUserCardComponent
],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  post: Post = {
    id: "test",
    createdAt: new Date(),
    media: [],
    userId: "test",
    userName: "mfgglr",
    name: "Muhammed Furkan Güler",
    userMedia:{
      containerName: "PostMedia",
      blobName: "image",
      type: MediaType.image,
      metadata: {width: 1187,height: 1599,duration: 0},
      transcodings: [],
      thumbnails: []
    }
  };

  media: Array<BaseMedia> = [];

  onFiles(event: Event){
    const input = event.target as HTMLInputElement;
    if (!input.files || input.files.length === 0) return;

    let media: LocalMedia[] = [];
    for(let i = 0; i < input.files.length; i++){
      media[i] = new LocalMedia(input.files[i])
    }
    this.media = [
      ...this.media,
      ...media
    ];
  }

  protected readonly title = signal('app_angular_client');
}
