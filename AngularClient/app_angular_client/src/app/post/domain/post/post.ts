import { PostContent } from '../post-content/post-content';
import { randomUUID } from 'crypto';
import { PostUser } from '../post-user';
import { PostMediaRequiredError } from './post-media-required-error';
import { PostMediaCountError } from './post-media-count-error';

export class Post {
  static readonly mediaContainerName: string = "PostMedia";
  static readonly maxMediaCount: number = 5;

  localId: string;
  remoteId?: string;
  createdAt: Date;
  updatedAt?: Date;
  content?: PostContent;
  user: PostUser;

  constructor(user: PostUser, content?: PostContent) {
    // if (media.length <= 0)
    //   throw new PostMediaRequiredError();

    // if (media.length > Post.maxMediaCount)
    //   throw new PostMediaCountError();

    this.localId = randomUUID()
    this.createdAt = new Date();
    this.content = content
    this.user = user;
  }

  updateContent(content: PostContent){
    this.content = content;
    this.updatedAt = new Date();
  }
}
