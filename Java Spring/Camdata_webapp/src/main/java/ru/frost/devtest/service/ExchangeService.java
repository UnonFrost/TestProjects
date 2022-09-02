package ru.frost.devtest.service;

import java.util.concurrent.CompletableFuture;

import ru.frost.devtest.dto.DataDto;
import ru.frost.devtest.dto.SourceDataDto;
import ru.frost.devtest.dto.TokenDataDto;

public interface ExchangeService {
	
	DataDto[] getData();
	
	CompletableFuture<SourceDataDto> getSourceData(String sourceUrl);
	
	CompletableFuture<TokenDataDto> getTokenData(String tokenUrl);
	
}
