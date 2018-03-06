using System;
using System.Collections.Generic;
using UtilityFramework.Application.ViewModels;

namespace UtilityFramework.Application
{
    public static class Utilities
    {
        /// <summary>
        /// RETORNO DE SUCESS
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ReturnViewModel ReturnSuccess(string message = "Sucesso", object data = null)
        {
            return new ReturnViewModel
            {
                Data = data,
                Message = message
            };
        }
        /// <summary>
        /// RETORNO DE ERRO COM EXCEPTION
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <param name="errors"></param>
        /// <param name="responseList"></param>
        /// <returns></returns>
        public static ReturnViewModel ReturnErro(this Exception ex, string message = "Ocorreu um erro, verifique e tente novamente", object data = null, object errors = null, bool responseList = false)
        {
            var messageEx = $"{ex.InnerException} {ex.Message}";

            return new ReturnViewModel
            {
                Data = !responseList ? data : new List<object>(),
                Erro = true,
                Errors = errors,

                MessageEx = messageEx,
                Message = message
            };
        }
        /// <summary>
        /// RETORNO DE ERRO FORÇADO
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <param name="errors"></param>
        /// <param name="responseList"></param>
        /// <returns></returns>
        public static ReturnViewModel ReturnErro(string message = "Ocorreu um erro, verifique e tente novamente", object data = null, object errors = null, bool responseList = false)
        {

            return new ReturnViewModel
            {
                Data = !responseList ? data : new List<object>(),
                Erro = true,
                Errors = errors,
                Message = message
            };
        }
    }
}