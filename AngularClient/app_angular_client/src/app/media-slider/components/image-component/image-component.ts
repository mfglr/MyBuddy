import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { LocalImageComponent } from '../local-image-component/local-image-component';
import { RemoteImageComponent } from '../remote-image-component/remote-image-component';
import { Dimension } from '../../models/dimension';
import { Media } from '../../models/media';
import { LocalMedia } from '../../models/local-media';
import { RemoteMedia } from '../../models/remote-media';


@Component({
  selector: 'app-image-component',
  imports: [
    LocalImageComponent,
    RemoteImageComponent
  ],
  templateUrl: './image-component.html',
  styleUrl: './image-component.scss',
})
export class ImageComponent{
  @Output() dimentionsReady = new EventEmitter<Dimension>();
  @Input() aspectRatio: number = 4 / 6;
  @Input() media!: Media;

  LocalMedia = LocalMedia;
  RemoteMedia = RemoteMedia;

  emitDimention(dimention: Dimension){
    this.dimentionsReady.emit(dimention);
  }
}
