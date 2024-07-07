using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Exercise;
using api.Dtos.Workout;
using api.Models;

namespace api.Mappers
{
    public static class ExerciseMapper
    {
        public static ExerciseDto ToExerciseDto(this Exercise exerciseModel)
        {
            return new ExerciseDto
            {
                Id = exerciseModel.Id,
                Name = exerciseModel.Name,
                MuscleGroup = exerciseModel.MuscleGroup
            };
        }

        public static Exercise ToExerciseFromCreateDto(this CreateExerciseRequestDto exerciseDto)
        {
            return new Exercise
            {
                Name = exerciseDto.Name,
                MuscleGroup = exerciseDto.MuscleGroup
            };
        }

        public static void UpdateExerciseFromDto(this Exercise exercise, UpdateExerciseRequestDto dto)
        {
            exercise.Name = dto.Name;
            exercise.MuscleGroup = dto.MuscleGroup;
        }
    }
}