using BlendoBot.Core.Command;
using BlendoBot.Core.Entities;
using BlendoBot.Core.Module;
using BlendoBot.Core.Utility;
using DSharpPlus.EventArgs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlendoBot.Module.RegionalIndicator;

internal class RegionalIndicatorCommand : ICommand {
	public RegionalIndicatorCommand(RegionalIndicator module) {
		this.module = module;
	}

	private readonly RegionalIndicator module;
	public IModule Module => module;

	public string Guid => "regionalindicator.command";
	public string DesiredTerm => "ri";
	public string Description => "Converts a message into lovely regional indicator text";
	public Dictionary<string, string> Usage => new() {
		{ "[message]", "Regionally indicates this message." },
		{ "Note", $"The regional indicator does not like uses of the {"<".Code()} and {">".Code()} characters. Also make sure your message is short enough to be encoded." }
	};

	public async Task OnMessage(MessageCreateEventArgs e, string[] tokenizedInput) {
		// First covert the original message to lower-case, and remove the original command.
		if (tokenizedInput.Length == 0) {
			await module.DiscordInteractor.Send(this, new SendEventArgs {
				Message = $"You must add something after the {module.ModuleManager.GetCommandTermWithPrefix(this)}!",
				Channel = e.Channel,
				Tag = "RegionalErrorNoMessage"
			});
			return;
		}
		string newString = RegionalIndicator.ConvertString(string.Join(' ', tokenizedInput));
		if (newString.Length <= 2000) {
			await module.DiscordInteractor.Send(this, new SendEventArgs {
				Message = newString.ToString(),
				Channel = e.Channel,
				Tag = "RegionalSuccess"
			});
		} else {
			await module.DiscordInteractor.Send(this, new SendEventArgs {
				Message = $"Regionalified message exceeds maximum character count by {newString.Length - 2000}. Shorten your message!",
				Channel = e.Channel,
				Tag = "RegionalErrorTooLong"
			});
		}
	}
}
