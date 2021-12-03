using LeftTuesday.Models;
using LeftTuesday.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Services
{
    public class ContentService
    {
        private ContentRepository _contentRepo;

        public ContentService(ContentRepository contentRepo)
        {
            _contentRepo = contentRepo;
        }

        public (Exception, Content) GetContent(int contentId)
        {
            //Todo add validation
            return _contentRepo.GetContent(contentId);
        }

        public (Exception, List<Content>) GetContents()
        {
            //Todo add validation
            return _contentRepo.GetContents();
        }

        public (Exception, long) CreateContent(Content content)
        {
            //Todo add validation

            return _contentRepo.AddContent(content);
        }

        public (Exception, Content) UpdateContent(Content content)
        {
            //Todo add validation
            var (error, original) = _contentRepo.GetContent(content.Id);

            if (error != null)
            {
                return (error, null);
            }

            if (original == null)
            {
                return (new Exception($"Content not found with id {content.Id}"), null);
            }

            if (content.Type != 0)
            {
                original.Type = content.Type;
            }

            if (!string.IsNullOrWhiteSpace(content.Value))
            {
                original.Value = content.Value;
            }

            return _contentRepo.UpdateContent(original);
        }

        public (Exception, bool) DeleteContent(int contentId)
        {
            //Todo cascade delete?
            return _contentRepo.DeleteContent(contentId);
        }
    }
}
