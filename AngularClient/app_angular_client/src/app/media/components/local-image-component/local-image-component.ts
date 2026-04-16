import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { LocalMedia } from '../../local-media';
import { Dimension } from '../../dimension';

@Component({
  selector: 'app-local-image-component',
  imports: [],
  templateUrl: './local-image-component.html',
  styleUrl: './local-image-component.scss',
})
export class LocalImageComponent implements OnInit, OnDestroy {
  @Output() dimentionCalculated = new EventEmitter<Dimension>();
  @Input() media!: LocalMedia;
  @Input() aspectRatio: number = 4 / 6;
  url?: string;

  ngOnInit(): void {
    this.url = URL.createObjectURL(this.media.file);
  }
  ngOnDestroy(): void {
    if(this.url)
      URL.revokeObjectURL(this.url);
  }

  emitDimension(image: HTMLImageElement){
    this.dimentionCalculated.emit(new Dimension(image.naturalWidth, image.naturalHeight));
  }
}
