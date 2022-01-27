using BlendoBot.Core.Module;
using BlendoBot.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlendoBot.Module.RegionalIndicator;

[Module(Guid = "com.biendeo.blendobot.module.regionalindicator", Name = "Regional Indicator", Author = "Biendeo", Version = "2.0.0", Url = "https://github.com/BlendoBot/BlendoBot.Module.RegionalIndicator")]
public class RegionalIndicator : IModule {
	public RegionalIndicator(IDiscordInteractor discordInteractor, IModuleManager moduleManager) {
		DiscordInteractor = discordInteractor;
		ModuleManager = moduleManager;

		RegionalIndicatorCommand = new(this);
	}

	internal ulong GuildId { get; private set; }

	internal readonly RegionalIndicatorCommand RegionalIndicatorCommand;

	internal readonly IDiscordInteractor DiscordInteractor;
	internal readonly IModuleManager ModuleManager;

	public Task<bool> Startup(ulong guildId) {
		GuildId = guildId;
		return Task.FromResult(ModuleManager.RegisterCommand(this, RegionalIndicatorCommand, out _));
	}

	internal static readonly Dictionary<char, string> CharacterMappings = new() {
		{ 'a', ":regional_indicator_a:" },
		{ 'b', ":regional_indicator_b:" },
		{ 'c', ":regional_indicator_c:" },
		{ 'd', ":regional_indicator_d:" },
		{ 'e', ":regional_indicator_e:" },
		{ 'f', ":regional_indicator_f:" },
		{ 'g', ":regional_indicator_g:" },
		{ 'h', ":regional_indicator_h:" },
		{ 'i', ":regional_indicator_i:" },
		{ 'j', ":regional_indicator_j:" },
		{ 'k', ":regional_indicator_k:" },
		{ 'l', ":regional_indicator_l:" },
		{ 'm', ":regional_indicator_m:" },
		{ 'n', ":regional_indicator_n:" },
		{ 'o', ":regional_indicator_o:" },
		{ 'p', ":regional_indicator_p:" },
		{ 'q', ":regional_indicator_q:" },
		{ 'r', ":regional_indicator_r:" },
		{ 's', ":regional_indicator_s:" },
		{ 't', ":regional_indicator_t:" },
		{ 'u', ":regional_indicator_u:" },
		{ 'v', ":regional_indicator_v:" },
		{ 'w', ":regional_indicator_w:" },
		{ 'x', ":regional_indicator_x:" },
		{ 'y', ":regional_indicator_y:" },
		{ 'z', ":regional_indicator_z:" },
		{ '1', ":one:" },
		{ '2', ":two:" },
		{ '3', ":three:" },
		{ '4', ":four:" },
		{ '5', ":five:" },
		{ '6', ":six:" },
		{ '7', ":seven:" },
		{ '8', ":eight:" },
		{ '9', ":nine:" },
		{ '0', ":zero:" },
		{ ' ', ":black_large_square:" },
		{ '!', ":grey_exclamation:" },
		{ '?', ":grey_question:" },
		{ '#', ":hash:" },
		{ '$', ":heavy_dollar_sign:" },
		{ '+', ":heavy_plus_sign:" },
		{ '-', ":heavy_minus_sign:" }
	};
}
