// ***********************************************************************
// Assembly         : OpenAC.Net.NFSe
// Author           : Leonardo Souza
// Created          : 08-01-2025
//
// Last Modified By : Leonardo Souza
// Last Modified On : 08-01-2025
// ***********************************************************************
// <copyright file="Tributus204ServiceClient.cs" company="OpenAC .Net">
//		        		   The MIT License (MIT)
//	     		    Copyright (c) 2014 - 2024 Projeto OpenAC .Net
//
//	 Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//	 The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//	 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using OpenAC.Net.Core.Extensions;
using OpenAC.Net.DFe.Core;
using OpenAC.Net.DFe.Core.Common;
using OpenAC.Net.NFSe.Commom;
using OpenAC.Net.NFSe.Commom.Client;
using OpenAC.Net.NFSe.Commom.Interface;
using OpenAC.Net.NFSe.Commom.Model;
using OpenAC.Net.NFSe.Commom.Types;

namespace OpenAC.Net.NFSe.Providers;

internal sealed class Tributus204ServiceClient : NFSeSoapServiceClient, IServiceClient
{
    #region Constructors

    public Tributus204ServiceClient(ProviderTributus204 provider, TipoUrl tipoUrl) : base(provider, tipoUrl, SoapVersion.Soap11)
    {
    }

    #endregion Constructors

    #region Methods

    public string Enviar(string cabec, string msg)
    {
        var message = new StringBuilder();
        message.Append("<nfse:RecepcionarLoteRpsRequest>");
        message.Append("<nfseCabecMsg>");
        message.AppendCData(cabec);
        message.Append("</nfseCabecMsg>");
        message.Append("<nfseDadosMsg>");
        message.AppendCData(msg);
        message.Append("</nfseDadosMsg>");
        message.Append("</nfse:RecepcionarLoteRpsRequest>");

        message.Replace("Id=", "id=");

        return Execute("AA24_RECEPCIONARLOTERPS.Execute", message.ToString(),
            "EnviarLoteRpsResposta");
    }

    public string EnviarSincrono(string cabec, string msg) =>
        throw new NotImplementedException("Função não implementada/suportada neste Provedor !");

    public string ConsultarSituacao(string cabec, string msg)
    {
        var message = new StringBuilder();
        message.Append("<e:ConsultarSituacaoLoteRPS.Execute>");
        message.Append("<e:Nfsecabecmsg>");
        message.AppendCData(cabec);
        message.Append("</e:Nfsecabecmsg>");
        message.Append("<e:Nfsedadosmsg>");
        message.AppendCData(msg);
        message.Append("</e:Nfsedadosmsg>");
        message.Append("</e:ConsultarSituacaoLoteRPS.Execute>");

        return Execute("http://www.e-nfs.com.braction/ACONSULTARSITUACAOLOTERPS.Execute", message.ToString(),
            "ConsultarSituacaoLoteRPS.ExecuteResponse");
    }

    public string ConsultarLoteRps(string cabec, string msg)
    {
        var message = new StringBuilder();
        message.Append("<nfse:ConsultarLoteRpsRequest>");
        message.Append("<nfseCabecMsg>");
        message.AppendCData(cabec);
        message.Append("</nfseCabecMsg>");
        message.Append("<nfseDadosMsg>");
        message.AppendCData(msg);
        message.Append("</nfseDadosMsg>");
        message.Append("</nfse:ConsultarLoteRpsRequest>");

        return Execute("ConsultarLoteRpsRequest", message.ToString(),
            "ConsultarLoteRpsResposta");
    }

    public string ConsultarSequencialRps(string cabec, string msg) =>
        throw new NotImplementedException("Função não implementada/suportada neste Provedor !");

    public string ConsultarNFSeRps(string cabec, string msg)
    {
        var message = new StringBuilder();
        message.Append("<e:A24_ConsultarNfsePorRps.Execute>");
        message.Append("<e:Nfsecabecmsg>");
        message.AppendCData(cabec);
        message.Append("</e:Nfsecabecmsg>");
        message.Append("<e:Nfsedadosmsg>");
        message.AppendCData(msg);
        message.Append("</e:Nfsedadosmsg>");
        message.Append("</e:A24_ConsultarNfsePorRps.Execute>");

        return Execute("AA24_CONSULTARNFSEPORRPS.Execute", message.ToString(),
            "ConsultarNfseRpsResposta");
    }

    public string ConsultarNFSe(string cabec, string msg)
    {
        var message = new StringBuilder();
        message.Append("<e:A24_ConsultarNfseServicoPrestado.Execute>");
        message.Append("<e:Nfsecabecmsg>");
        message.AppendCData(cabec);
        message.Append("</e:Nfsecabecmsg>");
        message.Append("<e:Nfsedadosmsg>");
        message.AppendCData(msg);
        message.Append("</e:Nfsedadosmsg>");
        message.Append("</e:A24_ConsultarNfseServicoPrestado.Execute>");

        return Execute("AA24_CONSULTARNFSESERVICOPRESTADO.Execute", message.ToString(),
            "ConsultarNfseServicoPrestadoResposta");
    }

    public string CancelarNFSe(string cabec, string msg)
    {
        var message = new StringBuilder();
        message.Append("<e:A24_CancelarNfse.Execute>");
        message.Append("<e:Nfsecabecmsg>");
        message.AppendCData(cabec);
        message.Append("</e:Nfsecabecmsg>");
        message.Append("<e:Nfsedadosmsg>");
        message.AppendCData(msg);
        message.Append("</e:Nfsedadosmsg>");
        message.Append("</e:A24_CancelarNfse.Execute>");

        return Execute("AA24_CANCELARNFSE.Execute", message.ToString(),
            "CancelarNfseResposta");
    }

    public string CancelarNFSeLote(string cabec, string msg) =>
        throw new NotImplementedException("Função não implementada/suportada neste Provedor !");

    public string SubstituirNFSe(string cabec, string msg)
    {
        var message = new StringBuilder();
        message.Append("<e:A24_SubstituirNfse.Execute>");
        message.Append("<e:Nfsecabecmsg>");
        message.AppendCData(cabec);
        message.Append("</e:Nfsecabecmsg>");
        message.Append("<e:Nfsedadosmsg>");
        message.AppendCData(msg);
        message.Append("</e:Nfsedadosmsg>");
        message.Append("</e:A24_SubstituirNfse.Execute>");

        return Execute("AA24_SUBSTITUIRNFSE.Execute", message.ToString(),
            "SubstituirNfseResposta");
    }

    private string Execute(string soapAction, string message, string responseTag)
    {
        return Execute($"http://www.e-nfs.com.braction/{soapAction}", message, "",
            [responseTag], ["xmlns:nfse=\"http://www.abrasf.org.br/nfse.xsd\""]);
    }

    protected override bool ValidarCertificadoServidor()
    {
        return Provider.Configuracoes.WebServices.Ambiente != DFeTipoAmbiente.Homologacao;
    }

    protected override string TratarRetorno(XElement xmlDocument, string[] responseTag)
    {
        var element = xmlDocument.ElementAnyNs("Fault");
        if (element == null)
        {
            element = responseTag.Aggregate(xmlDocument, (current, tag) => current.ElementAnyNs(tag));
            return element.ToString();
        }

        var exMessage = $"{element.ElementAnyNs("faultcode").GetValue<string>()} - {element.ElementAnyNs("faultstring").GetValue<string>()}";
        throw new OpenDFeCommunicationException(exMessage);

    }
    #endregion Methods
}