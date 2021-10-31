using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRT.HiringTracker.API.Helpers
{
    public static class EntityToDtoConvertor
    {
        #region Entity-2-DTO

        public static DTO.User Convert(Interfaces.Entities.User entity, IUrlHelper url)
        {
            var dto = new DTO.User()
            {
                Description = entity.Description,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Login = entity.Login,
                ID = entity.ID
            };

            dto.Links.Add(new DTO.Link(url.Action("GetUser", "users", new { id = dto.ID }), "self", "GET"));
            dto.Links.Add(new DTO.Link(url.Action("DeleteUser", "users", new { id = dto.ID }), "delete_user", "DELETE"));
            dto.Links.Add(new DTO.Link(url.Action("UpdateUser", "users"), "update_user", "PUT"));

            return dto;
        }

        public static DTO.PositionStatus Convert(Interfaces.Entities.PositionStatus entity, IUrlHelper url)
        {
            var dto = new DTO.PositionStatus()
            {
                Name = entity.Name,
                ID = entity.ID
            };

            return dto;
        }

        public static DTO.ProposalStatus Convert(Interfaces.Entities.ProposalStatus entity, IUrlHelper url)
        {
            var dto = new DTO.ProposalStatus()
            {
                Name = entity.Name,
                ID = entity.ID
            };

            return dto;
        }

        public static DTO.ProposalStep Convert(Interfaces.Entities.ProposalStep entity, IUrlHelper url)
        {
            var dto = new DTO.ProposalStep()
            {
                Name = entity.Name,
                ID = entity.ID,
                ReqDueDate = entity.ReqDueDate,
                RequiresRespInDays = entity.RequiresRespInDays
            };

            return dto;
        }

        public static DTO.Skill Convert(Interfaces.Entities.Skill entity, IUrlHelper url)
        {
            var dto = new DTO.Skill()
            {
                Name = entity.Name,
                ID = entity.ID
            };

            dto.Links.Add(new DTO.Link(url.Action("DeleteSkill", "skills", new { id = entity.ID }), "delete_skill", "DELETE"));
            dto.Links.Add(new DTO.Link(url.Action("UpdateSkill", "skills"), "update_skill", "PUT"));

            return dto;
        }

        public static DTO.PositionSkill Convert(Interfaces.Entities.PositionSkill entity,
                                        IDictionary<long, Interfaces.Entities.Skill> skills,
                                        IDictionary<long, Interfaces.Entities.SkillProficiency> profs,
                                        IUrlHelper url)
        {
            var dto = new DTO.PositionSkill()
            {
                IsMandatory = entity.IsMandatory,
                SkillProficiency = Convert(profs[entity.ProficiencyID], url),
                Skill = Convert(skills[entity.SkillID], url)
            };

            return dto;
        }

        public static DTO.CandidateSkill Convert(Interfaces.Entities.CandidateSkill entity,
                                        IDictionary<long, Interfaces.Entities.Skill> skills,
                                        IDictionary<long, Interfaces.Entities.SkillProficiency> profs,
                                        IUrlHelper url)
        {
            var dto = new DTO.CandidateSkill()
            {
                Proficiency = Convert(profs[entity.ProficiencyID], url),
                Skill = Convert(skills[entity.SkillID], url)
            };

            return dto;
        }

        public static DTO.SkillProficiency Convert(Interfaces.Entities.SkillProficiency entity, IUrlHelper url)
        {
            var dto = new DTO.SkillProficiency()
            {
                Name = entity.Name,
                ID = (long)entity.ID
            };

            dto.Links.Add(new DTO.Link(url.Action("DeleteSkillProficiency", "skillproficiencies", new { id = entity.ID }), "delete_proficiency", "DELETE"));
            dto.Links.Add(new DTO.Link(url.Action("UpdateSkillProficiency", "skillproficiencies"), "update_proficiency", "PUT"));

            return dto;
        }

        

        public static DTO.Candidate Convert(Interfaces.Entities.Candidate entity,
                                            IDictionary<long, Interfaces.Entities.User> users,
                                            IUrlHelper url)
        {
            var dto = new DTO.Candidate()
            {
                CreatedBy = Convert(users[(long)entity.CreatedByID], url),
                CreatedDate = (DateTime)entity.CreatedDate,
                ModifiedBy = entity.ModifiedByID != null ? Convert(users[(long)entity.ModifiedByID], url) : null,
                ModifiedDate = entity.ModifiedDate,
                ID = entity.ID ?? 0,
                CVLink = entity.CVLink,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                MiddleName = entity.MiddleName,
                Phone = entity.Phone                
            };

            dto.Links.Add(new DTO.Link(url.Action("GetCandidate", "candidates", new { id = dto.ID }), "self", "GET"));
            dto.Links.Add(new DTO.Link(url.Action("DeleteCandidate", "candidates", new { id = dto.ID }), "delete_candidate", "DELETE"));
            dto.Links.Add(new DTO.Link(url.Action("UpdateCandidate", "candidates"), "update_candidate", "PUT"));

            return dto;

        }

        public static DTO.Proposal Convert(Interfaces.Entities.Proposal entity, 
                                            IDictionary<long, Interfaces.Entities.Candidate> candidates,
                                            IDictionary<long, Interfaces.Entities.ProposalStatus> statuses,
                                            IDictionary<long, Interfaces.Entities.ProposalStep> steps,
                                            IDictionary<long, Interfaces.Entities.User> users,
                                            IDictionary<long, Interfaces.Entities.Position> positions,
                                            IDictionary<long, Interfaces.Entities.PositionStatus> positionStatuses,
                                            IUrlHelper url)
        {
            var dto = new DTO.Proposal()
            {
                Candidate = Convert(candidates[entity.CandidateID], users, url),
                CreatedBy = Convert(users[(long)entity.CreatedByID], url),
                CreatedDate = (DateTime)entity.CreatedDate,
                ModifiedBy = entity.ModifiedByID != null ? Convert(users[(long)entity.ModifiedByID], url) : null,
                ModifiedDate = entity.ModifiedDate,
                CurrentStep = Convert(steps[entity.CurrentStepID], url),
                DueDate = entity.DueDate,
                NextStep = entity.NextStepID != null ? Convert(steps[(long)entity.NextStepID], url) : null,
                Position = Convert(positions[entity.PositionID], positionStatuses, users, url),
                Proposed = entity.Proposed,
                Status = Convert(statuses[entity.StatusID], url),
                StepSetDate = entity.StepSetDate,
                ID = entity.ID
            };

            dto.Links.Add(new DTO.Link(url.Action("GetProposal", "proposals", new { id = dto.ID }), "self", "GET"));
            dto.Links.Add(new DTO.Link(url.Action("DeleteProposal", "proposals", new { id = dto.ID }), "delete_proposal", "DELETE"));
            dto.Links.Add(new DTO.Link(url.Action("UpdateProposal", "proposals"), "update_proposal", "PUT"));

            return dto;
        }

        #endregion

        #region DTO-2-Entity

        public static Interfaces.Entities.Proposal  Convert(DTO.Proposal dto)
        {
            var entity = new Interfaces.Entities.Proposal()
            {
                ID = dto.ID,
                CandidateID = (long)dto.Candidate.ID,
                CreatedByID = dto.CreatedBy.ID,
                CreatedDate = dto.CreatedDate,
                CurrentStepID = (long)dto.CurrentStep.ID,
                DueDate = dto.DueDate,
                ModifiedByID = dto.ModifiedBy.ID,
                ModifiedDate = dto.ModifiedDate,
                NextStepID = dto.NextStep.ID,
                PositionID = (long)dto.Position.ID,
                Proposed = dto.Proposed,
                StatusID = (long)dto.Status.ID,
                StepSetDate = dto.StepSetDate
            };

            return entity;
        }

        public static Interfaces.Entities.Skill Convert(DTO.Skill dto)
        {
            var entity = new Interfaces.Entities.Skill()
            {
                Name = dto.Name,
                ID = dto.ID
            };

            return entity;
        }

        public static Interfaces.Entities.User Convert(DTO.User dto)
        {
            var entity = new Interfaces.Entities.User()
            {
                Description = dto.Description,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Login = dto.Login,
                ID = dto.ID
            };

            return entity;
        }

        public static Interfaces.Entities.Position Convert(DTO.Position dto)
        {
            var entity = new Interfaces.Entities.Position()
            {
                Description = dto.Description,
                DepartmentID = dto.DepartmentID,
                ID = dto.ID,
                ShortDesc = dto.ShortDesc,
                StatusID = (long)dto.Status.ID,
                Title = dto.Title
            };

            return entity;
        }

        public static Interfaces.Entities.Candidate Convert(DTO.Candidate dto)
        {
            var entity = new Interfaces.Entities.Candidate()
            {
                ID = dto.ID,
                CVLink = dto.CVLink,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Phone = dto.Phone,
                MiddleName = dto.MiddleName
            };

            return entity;
        }

        public static Interfaces.Entities.PositionSkill Convert(DTO.PositionSkill dto)
        {
            var entity = new Interfaces.Entities.PositionSkill()
            {
                IsMandatory = dto.IsMandatory,
                SkillID = (long)dto.Skill.ID,
                ProficiencyID = dto.SkillProficiency.ID
            };

            return entity;
        }

        public static Interfaces.Entities.CandidateSkill Convert(DTO.CandidateSkill dto)
        {
            var entity = new Interfaces.Entities.CandidateSkill()
            {
                SkillID = (long)dto.Skill.ID,
                ProficiencyID = dto.Proficiency.ID
            };

            return entity;
        }

        #endregion
    }
}
