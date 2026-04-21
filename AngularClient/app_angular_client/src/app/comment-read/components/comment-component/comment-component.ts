import { Component, Input } from '@angular/core';
import { MediaCircular } from "../../../media-circular/media-circular";
import { Comment } from '../../models/comment';
import { NoUserMediaComponent } from "../../../shared/components/no-user-media-component/no-user-media-component";
import { Media } from '../../../media-core/media';
import { RemoteMedia } from '../../../media-core/remote-media';
import { Dimension } from '../../../media-core/dimension';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-comment-component',
  imports: [MediaCircular, NoUserMediaComponent, DatePipe],
  templateUrl: './comment-component.html',
  styleUrl: './comment-component.scss',
})
export class CommentComponent {
  @Input() comment!: Comment
  @Input() baseUrl?: string;
  @Input() userMediaDiameter: number = 48;
  @Input() isParent: boolean = true;

  map(media: Media): RemoteMedia{
    return new RemoteMedia(
      media.containerName,
      media.blobName,
      media.type,
      new Dimension(media.metadata.width,media.metadata.height)
    );
  }

}
