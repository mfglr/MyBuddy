import { Component, Input } from '@angular/core';
import { RemoteMedia } from '../../../media-core/remote-media';

@Component({
  selector: 'app-remote-media-circular',
  imports: [],
  templateUrl: './remote-media-circular.html',
  styleUrl: './remote-media-circular.scss',
})
export class RemoteMediaCircular {
  @Input() diameter!: number;
  @Input() image!: RemoteMedia;
  @Input() baseUrl!: string;

  url(){
    return `${this.baseUrl}/${this.image.containerName}/${this.image.blobName}`
  }
}
