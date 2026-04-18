import { Component, signal } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MediaSlider } from './media/components/media-slider/media-slider';
import { LocalMedia } from './media/local-media';
import { MediaTypeExtractor } from './media/services/media-type-extractor';
import { RemoteMedia } from './media/remote-media';
import { MediaType } from './media/media-type';
import { Metadata } from './media/metadata';
import { RemoteVideoComponent } from './media/components/remote-video-component/remote-video-component';
import { Media } from './media/media';
import { Meta } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  imports: [
    ReactiveFormsModule,
    MediaSlider,
],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  media: Media[] = [
    // new RemoteMedia(
    //     "PostMedia",
    //     "image",
    //     MediaType.image,
    //     new Metadata(1187,1599,0)
    //   ),
    //   new RemoteMedia(
    //     "PostMedia",
    //     "video",
    //     MediaType.video,
    //     new Metadata(1280,720,0)
    //   )
    ];
  mediaTypeExtractor: MediaTypeExtractor;

  constructor(mediaTypeExtractor: MediaTypeExtractor) {
    this.mediaTypeExtractor = mediaTypeExtractor;
  }

  onFiles(event: Event){
    const input = event.target as HTMLInputElement;
    if (!input.files || input.files.length === 0) return;

    let media: LocalMedia[] = [];
    for(let i = 0; i < input.files.length; i++){
      media[i] = new LocalMedia(
        this.mediaTypeExtractor.extract(input.files[i]),
        input.files[i]
      )
    }
    this.media = [
      ...this.media,
      ...media
    ];
  }

  protected readonly title = signal('app_angular_client');
}
