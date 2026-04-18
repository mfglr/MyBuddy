import { Component, Input } from '@angular/core';
import { RemoteMedia } from '../../models/remote-media';

@Component({
  selector: 'app-remote-image-component',
  imports: [],
  templateUrl: './remote-image-component.html',
  styleUrl: './remote-image-component.scss',
})
export class RemoteImageComponent {
  @Input() media!: RemoteMedia;
  @Input() aspectRatio: number = 4 / 6;
}
