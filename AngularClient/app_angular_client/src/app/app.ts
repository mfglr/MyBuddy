import { Component, signal } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { LocalMedia } from './media-core/local-media';
import { MediaSlider } from './media-slider/media-slider';
import { BaseMedia } from './media-core/base-media';
import { MediaCircular } from './media-circular/media-circular';
import { RemoteMedia } from './media-core/remote-media';
import { MediaType } from './media-core/media-type';
import { Dimension } from './media-core/dimension';

@Component({
  selector: 'app-root',
  imports: [
    ReactiveFormsModule,
    MediaSlider,
    MediaCircular
],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  media: BaseMedia[] = [
    new RemoteMedia(
        "PostMedia",
        "image",
        MediaType.image,
        new Dimension(1187,1599)
      ),
    //   new RemoteMedia(
    //     "PostMedia",
    //     "video",
    //     MediaType.video,
    //     new Dimension(1280,720)
    //   )
    ];

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
