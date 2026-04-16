import Dexie, { PromiseExtended, Table } from 'dexie';
import { Post } from '../domain/post/post';

export class PostLocalDataSource extends Dexie {
  items!: Table<Post,string>;

  constructor() {
    super("MyAppDB");
  }

  create(post: Post): PromiseExtended<string>{
    return this.items.add(post, post.localId);
  }

}
