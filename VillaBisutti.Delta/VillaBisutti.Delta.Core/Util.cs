﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta
{
	public static class Util
	{
		public static string GetDescription(this Enum value)
		{
			FieldInfo field = value.GetType().GetField(value.ToString());
			DescriptionAttribute DescAttribute =
				field.GetCustomAttribute<DescriptionAttribute>();
			if (DescAttribute != null)
				return DescAttribute.Description;
			DisplayAttribute DisplayAttribute =
				field.GetCustomAttribute<DisplayAttribute>();
			if (DisplayAttribute != null)
				return DisplayAttribute.Name;
			return value.ToString();
		}
        internal static T Get<T>(string name)
        {
            string config = ConfigurationManager.AppSettings[name];
            T value = default(T);
            if (!String.IsNullOrEmpty(config))
            {
                
                value = (T)Convert.ChangeType(config, typeof(T));
                return value;
            }
            return value;
        }

        internal static List<T> GetList<T>(string name, char separator = ',')
        {
            string config = ConfigurationManager.AppSettings[name];
            List<T> value = new List<T>();
            if (!String.IsNullOrEmpty(config))
            {
                value = config.Split(separator).Cast<T>().ToList();
                return value;
            }
            return value;
        }

        public static void ImageToFolder(string file, string nomeEvento)
        {

        }

        /*TODO: Imagem
         * Redimencionar a imagem
         * Colocar a mensagem dentro da imagem: Imagem meramente ilustrativa
         * ver de qual evento se trata
         * criar a pasta para o evento da imagem(se ja tiver, só coloca na pasta)
         * colocar o nome da imagem de acordo com a data e hora (yyyymmdd HH:mm:ss) dentro da pasta
         * */
        
	}
}
