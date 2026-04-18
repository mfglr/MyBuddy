import { Component, Input } from '@angular/core';
import { BaseMedia } from '../media-core/base-media';
import { LocalMedia } from '../media-core/local-media';
import { RemoteMediaCircular } from './components/remote-media-circular/remote-media-circular';
import { RemoteMedia } from '../media-core/remote-media';
import { LocalMediaCircular } from './components/local-media-circular/local-media-circular';

@Component({
  selector: 'app-media-circular',
  imports: [
    LocalMediaCircular,
    RemoteMediaCircular
  ],
  templateUrl: './media-circular.html',
  styleUrl: './media-circular.scss',
})
export class MediaCircular {
  @Input() diameter : number = 60;
  @Input() image!: BaseMedia;
  @Input() blobServiceUrl!: string;

  LocalMedia = LocalMedia;
  RemoteMedia = RemoteMedia;
}
