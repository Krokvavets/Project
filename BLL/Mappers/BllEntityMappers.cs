using BLL.Interface.Entities;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class BllEntityMappers
    {
        #region User
        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            if (ReferenceEquals(userEntity, null)) return null;
            return new DalUser()
            {
                Id = userEntity.Id,
                Email = userEntity.Email,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Nickname = userEntity.Nickname,
                Password = userEntity.Password,
                Photo = userEntity.Photo,
                CreationDate = userEntity.CreationDate,
                NumberOfPosts = userEntity.NumberOfPosts,
                AboutMe = userEntity.AboutMe
            };
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            if (ReferenceEquals(dalUser, null)) return null;
            return new UserEntity()
            {
                Id = dalUser.Id,
                Email = dalUser.Email,
                FirstName = dalUser.FirstName,
                LastName = dalUser.LastName,
                Nickname = dalUser.Nickname,
                Password = dalUser.Password,
                Photo = dalUser.Photo,
                CreationDate = dalUser.CreationDate,
                NumberOfPosts = dalUser.NumberOfPosts,
                AboutMe = dalUser.AboutMe
            };
        }
        #endregion

        #region Role
        public static DalRole ToDalRole(this RoleEntity roleEntity)
        {
            if (ReferenceEquals(roleEntity, null)) return null;
            return new DalRole()
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name
            };
        }

        public static RoleEntity ToBllRole(this DalRole dalRole)
        {
            if (ReferenceEquals(dalRole, null)) return null;
            return new RoleEntity()
            {
                Id = dalRole.Id,
                Name = dalRole.Name
            };
        }
        public static List<RoleEntity> ToListBll(this IEnumerable<DalRole> listDal)
        {
            List<RoleEntity> list = new List<RoleEntity>();
            foreach (var item in listDal)
                list.Add(item.ToBllRole());
            return list;
        }
        #endregion

        #region Topic
        public static DalTopic ToDalTopic(this TopicEntity topicEntity)
        {
            if (ReferenceEquals(topicEntity, null)) return null;
            return new DalTopic()
            {
                Id = topicEntity.Id,
                Name = topicEntity.Name,
               SectionId = topicEntity.SectionId 
            };
        }

        public static TopicEntity ToBllTopic(this DalTopic dalTopic)
        {
            if (ReferenceEquals(dalTopic, null)) return null;
            return new TopicEntity()
            {
                Id = dalTopic.Id,
                Name = dalTopic.Name,
                SectionId = dalTopic.SectionId
            };
        }

        public static IEnumerable<DalTopic> ToDalTopicList(this IEnumerable<TopicEntity> sectionEnties)
        {
            var list = new List<DalTopic>();
            foreach (var item in sectionEnties)
                list.Add(item.ToDalTopic());
            return list;
        }

        public static IEnumerable<TopicEntity> ToBllTopicList(this IEnumerable<DalTopic> dalSections)
        {
            var list = new List<TopicEntity>();
            foreach (var item in dalSections)
                list.Add(item.ToBllTopic());
            return list;
        }
        #endregion

        #region Message
        public static DalMessage ToDalMessage(this MessageEntity messageEntity)
        {
            if (ReferenceEquals(messageEntity, null)) return null;
            return new DalMessage()
            {
                Id = messageEntity.Id,
                Footer = messageEntity.Footer,
                Note = messageEntity.Note,
                Quote = messageEntity.Quote,
                UserId = messageEntity.UserId,
                Text = messageEntity.Text,
                TopicId = messageEntity.TopicId,
                CreationDate = messageEntity.CreationDate
            };
        }

        public static MessageEntity ToBllMessage(this DalMessage dalMessage)
        {
            if (ReferenceEquals(dalMessage, null)) return null;
            return new MessageEntity()
            {
                Id = dalMessage.Id,
                Footer = dalMessage.Footer,
                Note = dalMessage.Note,
                Quote = dalMessage.Quote,
                UserId = dalMessage.UserId,
                Text = dalMessage.Text,
                TopicId = dalMessage.TopicId,
                CreationDate = dalMessage.CreationDate
            };
        }
        public static IEnumerable<MessageEntity> ToBllMessageList(this IEnumerable<DalMessage> dalMessage)
        {
            if (ReferenceEquals(dalMessage, null)) return null;
            var list = new List<MessageEntity>();
                foreach (var item in dalMessage)
                    list.Add(item.ToBllMessage());
            return list;
        }
        #endregion

        #region PrivateMessage

        public static DalPrivateMessage ToDalPrivateMessage(this PrivateMessageEntity privateMessageEntity)
        {
            if (ReferenceEquals(privateMessageEntity, null)) return null;
            return new DalPrivateMessage()
            {
                Id = privateMessageEntity.Id,
                Preview = privateMessageEntity.Preview,
                RecipientId = privateMessageEntity.RecipientId,
                SenderId = privateMessageEntity.SenderId,
                Status = privateMessageEntity.Status,
                Text = privateMessageEntity.Text
            };
        }

        public static PrivateMessageEntity ToBllPrivateMessage(this DalPrivateMessage dalPrivateMessage)
        {
            if (ReferenceEquals(dalPrivateMessage, null)) return null;
            return new PrivateMessageEntity()
            {
                Id = dalPrivateMessage.Id,
                Preview = dalPrivateMessage.Preview,
                RecipientId = dalPrivateMessage.RecipientId,
                SenderId = dalPrivateMessage.SenderId,
                Status = dalPrivateMessage.Status,
                Text = dalPrivateMessage.Text
            };
        }

        #endregion

        #region Section

        public static DalSection ToDalSection(this SectionEntity sectionEntity)
        {
            if (ReferenceEquals(sectionEntity, null)) return null;
            return new DalSection()
            {
                Id = sectionEntity.Id,
                Name = sectionEntity.Name
            };
        }

        public static SectionEntity ToBllSection(this DalSection dalSection)
        {
            if (ReferenceEquals(dalSection, null)) return null;
            return new SectionEntity()
            {
                Id = dalSection.Id,
                Name = dalSection.Name
            };
        }
        public static IEnumerable<DalSection> ToDalSectionList(this IEnumerable<SectionEntity> sectionEnties)
        {
            if (!ReferenceEquals(sectionEnties, null)) return null;
            var list = new List<DalSection>();
            foreach (var item in sectionEnties)
                list.Add(item.ToDalSection());
            return list;
        }

        public static IEnumerable<SectionEntity> ToBllSectionList(this IEnumerable<DalSection> dalSections)
        {
            if (!ReferenceEquals(dalSections, null)) return null;
            var list = new List<SectionEntity>();
            foreach (var item in dalSections)
                list.Add(item.ToBllSection());
            return list;
        }

        #endregion
    }
}
