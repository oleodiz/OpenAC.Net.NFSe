using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Linq;
using System.Xml.Linq;
using OpenAC.Net.Core.Extensions;
using OpenAC.Net.DFe.Core;
using OpenAC.Net.DFe.Core.Serializer;
using OpenAC.Net.NFSe.Commom;
using OpenAC.Net.NFSe.Commom.Interface;
using OpenAC.Net.NFSe.Commom.Model;
using OpenAC.Net.NFSe.Commom.Types;
using OpenAC.Net.NFSe.Configuracao;
using OpenAC.Net.NFSe.Nota;

namespace OpenAC.Net.NFSe.Providers;

internal sealed class ProviderTributus204 : ProviderABRASF204
{
    #region Constructors

    public ProviderTributus204(ConfigNFSe config, OpenMunicipioNFSe municipio) : base(config, municipio)
    {
        Name = "Tributus";
    }

    #endregion Constructors

    #region Methods

    protected override string GerarCabecalho()
        => $"<cabecalho {GetNamespace()}><versaoDados>2.04</versaoDados></cabecalho>";

    protected override IServiceClient GetClient(TipoUrl tipo) => new Tributus204ServiceClient(this, tipo);


    protected override void AssinarEnviar(RetornoEnviar retornoWebservice)
    {
        retornoWebservice.XmlEnvio = XmlSigning.AssinarXml(retornoWebservice.XmlEnvio, "EnviarLoteRpsEnvio", "LoteRps", Certificado);
    }

    protected override bool PrecisaValidarSchema(TipoUrl tipo)
    {
        return false;
    }

    protected override XElement WriteRpsRps(NotaServico nota)
    {
        var rps = base.WriteRpsRps(nota);
        rps.AddAttribute(new XAttribute("id", nota.IdentificacaoRps.Numero));
        return rps;
    }

    protected override void TratarRetornoEnviar(RetornoEnviar retornoWebservice, NotaServicoCollection notas)
    {
        base.TratarRetornoEnviar(retornoWebservice, notas);
    }


    #endregion Methods
}