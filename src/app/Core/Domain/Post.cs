using System;

namespace FakeVader.Core.Domain {
    public class Post {
        public Post(string title, string text) : this(title, text, DateTime.Now) {
        }

        public Post(string title, string text, DateTime publishDate) {
            Title = title;
            Text = text;
            PublishDate = publishDate;
            Permalink = title.Replace(' ', '+').Replace('/', '-').Replace('\\', '-');
        }

        protected Post() {
        }

        public virtual int Id { get; private set; }
        public virtual string Title { get; private set; }
        public virtual string Text { get; private set; }
        public virtual DateTime PublishDate { get; private set; }
        public virtual string Permalink { get; private set; }
    }
}