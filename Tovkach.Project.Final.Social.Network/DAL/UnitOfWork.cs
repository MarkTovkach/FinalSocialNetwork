using System;
using Infrastructure;
using DAL.EF;

namespace DAL
{
    public class UnitOfWork : IDisposable
    {
        private IGenericRepository<User> _userRepository;
        private IGenericRepository<Role> _roleRepository;
        private IGenericRepository<Message> _messageRepository;
        private IGenericRepository<Post> _postRepository;
        private SocialNetwork _context;

        public UnitOfWork(
            SocialNetwork context,
            IGenericRepository<User> userRepository,
            IGenericRepository<Role> roleRepository,
            IGenericRepository<Message> messageRepository,
            IGenericRepository<Post> postRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _messageRepository = messageRepository;
            _postRepository = postRepository;
        }

        public IGenericRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new EfRepository<SocialNetwork, User>(_context);
                }
                return _userRepository;
            }
        }
        public IGenericRepository<Role> RoleRepository
        {
            get
            {
                if (this._roleRepository == null)
                {
                    this._roleRepository = new EfRepository<SocialNetwork, Role>(_context);
                }
                return _roleRepository;
            }
        }
        public IGenericRepository<Message> MessageRepository
        {
            get
            {
                if (this._messageRepository == null)
                {
                    this._messageRepository = new EfRepository<SocialNetwork, Message>(_context);
                }
                return _messageRepository;
            }
        }
        public IGenericRepository<Post> PostRepository
        {
            get
            {
                if (this._postRepository == null)
                {
                    this._postRepository = new EfRepository<SocialNetwork, Post>(_context);
                }
                return _postRepository;
            }
        }


        public void Save()
        {
            _context.SaveChanges();
        }


        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed == false)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
