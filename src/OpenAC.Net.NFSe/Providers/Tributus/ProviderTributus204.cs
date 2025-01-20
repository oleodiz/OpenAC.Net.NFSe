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
        => $"<cabecalho versao=\"201001\" {GetNamespace()}><versaoDados>2.04</versaoDados></cabecalho>";

    protected override IServiceClient GetClient(TipoUrl tipo) => new Tributus204ServiceClient(this, tipo);

    #endregion Methods
}