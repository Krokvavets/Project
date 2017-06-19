using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Infrastructure
{
    public static class PLMappers
    {
        #region User
        public static ProfileViewModel ToProfileViewModel(this UserEntity userEntity)
        {
            if (ReferenceEquals(userEntity, null)) return null;
            return new ProfileViewModel()
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

        public static UserEntity ToBllUser(this ProfileViewModel profileViewModel)
        {
            if (ReferenceEquals(profileViewModel, null)) return null;
            return new UserEntity()
            {
                Id = profileViewModel.Id,
                Email = profileViewModel.Email,
                FirstName = profileViewModel.FirstName,
                LastName = profileViewModel.LastName,
                Nickname = profileViewModel.Nickname,
                Password = profileViewModel.Password,
                Photo = profileViewModel.Photo,
                CreationDate = profileViewModel.CreationDate,
                NumberOfPosts = profileViewModel.NumberOfPosts,
                AboutMe = profileViewModel.AboutMe
            };
        }
        #endregion
        #region Section
        public static SectionViewModel ToDalSectionViewModel(this SectionEntity sectionEntity, ISectionService servece)
        {
            if (ReferenceEquals(sectionEntity, null)) return null;
            return new SectionViewModel()
            {
                Id = sectionEntity.Id,
                Name = sectionEntity.Name,
                Topics = servece.GetTopics(sectionEntity.Id).ToList()
            };
        }

        public static SectionEntity ToBllSection(this SectionViewModel viewModelSection)
        {
            if (ReferenceEquals(viewModelSection, null)) return null;
            return new SectionEntity()
            {
                Id = viewModelSection.Id,
                Name = viewModelSection.Name
            };
        }
        public static IEnumerable<SectionViewModel> ToSectionViewModel(this IEnumerable<SectionEntity> sectionEnties, ISectionService servece)
        {
            var list = new List<SectionViewModel>();
            foreach (var item in sectionEnties)
                list.Add(item.ToDalSectionViewModel(servece));
            return list;
        }
        #endregion

        #region Topic
        public static TopicViewModel ToViewTopicViewModel(this TopicEntity topicEntity)
        {
            if (ReferenceEquals(topicEntity, null)) return null;
            return new TopicViewModel()
            {
                Id = topicEntity.Id,
                Name = topicEntity.Name,
                SectionId = topicEntity.SectionId
            };
        }

        public static TopicEntity ToBllTopic(this TopicViewModel topicviewModel)
        {
            if (ReferenceEquals(topicviewModel, null)) return null;
            return new TopicEntity()
            {
                Id = topicviewModel.Id,
                Name = topicviewModel.Name,
                SectionId = topicviewModel.SectionId
            };
        }
        #endregion
    }
}